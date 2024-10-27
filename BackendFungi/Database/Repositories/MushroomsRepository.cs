using BackendFungi.Abstractions;
using BackendFungi.Database.Context;
using BackendFungi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendFungi.Database.Repositories;

public class MushroomsRepository : IMushroomsRepository
{
    private readonly FungiDbContext _context;
    private readonly IDoppelgangersRepository _doppelgangersRepository;

    public MushroomsRepository(FungiDbContext context, IDoppelgangersRepository doppelgangersRepository)
    {
        _context = context;
        _doppelgangersRepository = doppelgangersRepository;
    }

    // Creates a mushroom and doppelgangers to it in the database according to the mushroom model,
    // returns the id of the created mushroom
    public async Task<Guid> CreateMushroom(Mushroom mushroom)
    {
        var mushroomEntity = new Entities.Mushroom
        {
            Id = mushroom.Id,
            Name = mushroom.Name,
            SynonymousName = mushroom.SynonymousName,
            RedBook = mushroom.RedBook,
            Eatable = mushroom.Eatable,
            HasStem = mushroom.HasStem,
            StemSizeFrom = mushroom.StemSizeFrom,
            StemSizeTo = mushroom.StemSizeTo,
            StemType = mushroom.StemType,
            StemColor = mushroom.StemColor,
            Description = mushroom.Description
        };

        await _context.Mushrooms.AddAsync(mushroomEntity);
        await _context.SaveChangesAsync();

        var addedDoppelgangers = new List<Guid>();
        foreach (var doppelganger in mushroom.Doppelgangers)
        {
            addedDoppelgangers.Add(await _doppelgangersRepository.CreateDoppelganger(doppelganger));
        }

        return mushroom.Id;
    }

    // Gets list of all mushrooms and doppelgangers to them from the database
    public async Task<List<Mushroom>> GetAllMushrooms()
    {
        var mushroomEntities = await _context.Mushrooms
            .AsNoTracking()
            .ToListAsync();

        var mushrooms = new List<Mushroom>();

        foreach (var mushroomEntity in mushroomEntities)
        {
            var doppelgangers = await _doppelgangersRepository
                .GetMushroomDoppelgangers(mushroomEntity.Id);

            mushrooms.Add(Mushroom.Create(
                mushroomEntity.Id,
                mushroomEntity.Name,
                mushroomEntity.SynonymousName,
                mushroomEntity.RedBook,
                mushroomEntity.Eatable,
                mushroomEntity.HasStem,
                mushroomEntity.StemSizeFrom,
                mushroomEntity.StemSizeTo,
                mushroomEntity.StemType,
                mushroomEntity.StemColor,
                mushroomEntity.Description,
                doppelgangers).Mushroom);
        }

        return mushrooms;
    }

    // Finds the mushroom id by name in the database and returns it
    public async Task<Guid> GetMushroomId(string mushroomName)
    {
        var mushroomEntity = await (from mushroom in _context.Mushrooms
            where mushroom.Name == mushroomName
            select mushroom).FirstOrDefaultAsync();
        if (mushroomEntity == null)
            throw new Exception("Unknown mushroom name");

        return mushroomEntity.Id;
    }

    // Finds a mushroom by id and returns it
    public async Task<Mushroom> GetMushroom(Guid mushroomId)
    {
        var mushroomEntity = await (from m in _context.Mushrooms
            where m.Id == mushroomId
            select m).FirstOrDefaultAsync();
        if (mushroomEntity == null)
            throw new Exception("Unknown mushroom name");

        var doppelgangers = await _doppelgangersRepository
            .GetMushroomDoppelgangers(mushroomEntity.Id);

        var mushroom = Mushroom.Create(
            mushroomEntity.Id,
            mushroomEntity.Name,
            mushroomEntity.SynonymousName,
            mushroomEntity.RedBook,
            mushroomEntity.Eatable,
            mushroomEntity.HasStem,
            mushroomEntity.StemSizeFrom,
            mushroomEntity.StemSizeTo,
            mushroomEntity.StemType,
            mushroomEntity.StemColor,
            mushroomEntity.Description,
            doppelgangers).Mushroom;

        return mushroom;
    }

    // Gets new parameters for a mushroom, deletes all doppelgangers for the searched mushroom,
    // updates the mushroom parameters and creates new doppelgangers for it
    public async Task<Guid> UpdateMushroom(Guid mushroomId, Mushroom newMushroomModel)
    {
        var oldMushroom = await GetMushroom(mushroomId);

        foreach (var doppelganger in oldMushroom.Doppelgangers)
        {
            await _doppelgangersRepository.DeleteDoppelganger(doppelganger.Id);
        }

        await _context.Mushrooms
            .Where(m => m.Id == mushroomId)
            .ExecuteUpdateAsync(x => x
                .SetProperty(m => m.Name, m => newMushroomModel.Name)
                .SetProperty(m => m.SynonymousName, m => newMushroomModel.SynonymousName)
                .SetProperty(m => m.RedBook, m => newMushroomModel.RedBook)
                .SetProperty(m => m.Eatable, m => newMushroomModel.Eatable)
                .SetProperty(m => m.HasStem, m => newMushroomModel.HasStem)
                .SetProperty(m => m.StemSizeFrom, m => newMushroomModel.StemSizeFrom)
                .SetProperty(m => m.StemSizeTo, m => newMushroomModel.StemSizeTo)
                .SetProperty(m => m.StemType, m => newMushroomModel.StemType)
                .SetProperty(m => m.StemColor, m => newMushroomModel.StemColor)
                .SetProperty(m => m.Description, m => newMushroomModel.Description));

        foreach (var doppelganger in newMushroomModel.Doppelgangers)
        {
            await _doppelgangersRepository.CreateDoppelganger(doppelganger);
        }

        return mushroomId;
    }

    // Deletes a mushroom, and along with it, thanks to the database settings,
    // all its doppelgangers are deleted, returns the id of the deleted mushroom
    public async Task<Guid> DeleteMushroom(Guid mushroomId)
    {
        var numUpdated = await _context.Mushrooms
            .Where(m => m.Id == mushroomId)
            .ExecuteDeleteAsync();
        
        if (numUpdated == 0)
        {
            throw new Exception("Unknown mushroom id");
        }

        return mushroomId;
    }
}