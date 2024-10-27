using BackendFungi.Abstractions;
using BackendFungi.Database.Context;
using BackendFungi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendFungi.Database.Repositories;

public class DoppelgangersRepository : IDoppelgangersRepository
{
    private readonly FungiDbContext _context;

    public DoppelgangersRepository(FungiDbContext context)
    {
        _context = context;
    }

    // Creating a doppelganger in the doppelganger table, returns the id of the created doppelganger
    public async Task<Guid> CreateDoppelganger(Doppelganger doppelganger)
    {
        var doppelgangerEntity = new Entities.Doppelganger
        {
            Id = doppelganger.Id,
            MushroomId = doppelganger.MushroomId,
            DoppelgangerName = doppelganger.DoppelgangerName
        };

        await _context.Doppelgangers.AddAsync(doppelgangerEntity);
        await _context.SaveChangesAsync();

        return doppelgangerEntity.Id;
    }

    // Gets a list of mushroom doppelgangers, replaces getting a single doppelganger,
    // because we only need to get a set of mushroom doppelgangers
    public async Task<List<Doppelganger>> GetMushroomDoppelgangers(Guid mushroomId)
    {
        var doppelgangerEntities = await (from doppelganger in _context.Doppelgangers
                where doppelganger.MushroomId == mushroomId
                select doppelganger)
            .OrderBy(x => x.DoppelgangerName)
            .AsNoTracking()
            .ToListAsync();

        var doppelgangers = doppelgangerEntities
            .Select(d => Doppelganger.Create(d.Id, d.MushroomId, d.DoppelgangerName).Doppelganger)
            .ToList();

        if (doppelgangers.Count == 0)
        {
            throw new Exception("Unknown mushroom id");
        }

        return doppelgangers;
    }

    // The Update function is not needed, because when the mushroom is changed,
    // doppelgangers should be deleted and recreated

    // Deleting a doppelganger in the doppelganger table, returns the id of the deleted doppelganger
    public async Task<Guid> DeleteDoppelganger(Guid doppelgangerId)
    {
        var numUpdated = await _context.Doppelgangers
            .Where(d => d.Id == doppelgangerId)
            .ExecuteDeleteAsync();

        if (numUpdated == 0)
        {
            throw new Exception("Unknown doppelganger id");
        }

        return doppelgangerId;
    }
}