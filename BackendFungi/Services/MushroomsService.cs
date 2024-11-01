using BackendFungi.Abstractions;
using BackendFungi.Contracts;
using BackendFungi.Models;

namespace BackendFungi.Services;

public class MushroomsService : IMushroomsService
{
    private readonly IMushroomsRepository _mushroomsRepository;

    public MushroomsService(IMushroomsRepository mushroomsRepository)
    {
        _mushroomsRepository = mushroomsRepository;
    }

    // Returns a mushroom model based on the mushroom name, also returns a doppelgangers map,
    // which displays whether the corresponding doppelganger is in the database
    public async Task<(Mushroom Mushroom, List<bool> DoppelgangersMap)>
        GetMushroomAsync(string mushroomName, CancellationToken ct)
    {
        try
        {
            var mushroomId = await _mushroomsRepository.GetMushroomId(mushroomName);

            var mushroom = await _mushroomsRepository.GetMushroom(mushroomId);

            var doppelgangersMap = new List<bool>();
            foreach (var doppelganger in mushroom.Doppelgangers)
            {
                try
                {
                    await _mushroomsRepository.GetMushroomId(doppelganger.DoppelgangerName);

                    doppelgangersMap.Add(true);
                }
                catch (Exception)
                {
                    doppelgangersMap.Add(false);
                }
            }

            return (mushroom, doppelgangersMap);
        }
        catch (Exception e)
        {
            throw new Exception($"Unable to get mushroom \"{mushroomName}\": \"{e.Message}\"");
        }
    }

    // Returns a list of all mushrooms models and doppelgangers map for them
    public async Task<List<(Mushroom Mushroom, List<bool> DoppelgangersMap)>>
        GetAllMushroomsAsync(CancellationToken ct)
    {
        try
        {
            var mushrooms = await _mushroomsRepository.GetAllMushrooms();

            var result = new List<(Mushroom, List<bool> DoppelgangersMap)>();
            foreach (var mushroom in mushrooms)
            {
                var doppelgangersMap = new List<bool>();
                foreach (var doppelganger in mushroom.Doppelgangers)
                {
                    try
                    {
                        await _mushroomsRepository.GetMushroomId(doppelganger.DoppelgangerName);

                        doppelgangersMap.Add(true);
                    }
                    catch (Exception)
                    {
                        doppelgangersMap.Add(false);
                    }
                }

                result.Add((mushroom, doppelgangersMap));
            }

            return result;
        }
        catch (Exception e)
        {
            throw new Exception($"Unable to get mushrooms: \"{e.Message}\"");
        }
    }

    // Returns a list of mushrooms after filtering
    public async Task<List<(Mushroom Mushroom, List<bool> DoppelgangersMap)>> 
        GetFilteredMushroomsAsync(GetFilterMushroomRequest filterMushroomDto, CancellationToken ct)
    {
        var mushrooms = await _mushroomsRepository.GetAllMushrooms();

        try
        {
            if(filterMushroomDto.PartOfName is not null)
            {
                mushrooms = mushrooms
                    .Where(
                    mushroom => mushroom.Name.Contains(filterMushroomDto.PartOfName) || 
                    mushroom.SynonymousName is not null && mushroom.SynonymousName.Contains(filterMushroomDto.PartOfName)
                    )
                    .ToList();
            }

            if(filterMushroomDto.Redbook is not null)
            {
                mushrooms = mushrooms
                    .Where(mushroom => mushroom.RedBook == filterMushroomDto.Redbook)
                    .ToList();
            }

            if (filterMushroomDto.Eatable is not null)
            {
                mushrooms = mushrooms
                    .Where(mushroom => mushroom.Eatable == filterMushroomDto.Eatable)
                    .ToList();
            }

            if (filterMushroomDto.HasStem is not null)
            {
                mushrooms = mushrooms
                    .Where(mushroom => mushroom.HasStem == filterMushroomDto.HasStem)
                    .ToList();
            }

            if (filterMushroomDto.StemSizeFrom is not null)
            {
                mushrooms = mushrooms
                    .Where(mushroom => mushroom.StemSizeFrom >= filterMushroomDto.StemSizeFrom)
                    .ToList();
            }

            if (filterMushroomDto.StemSizeTo is not null)
            {
                mushrooms = mushrooms
                    .Where(mushroom => mushroom.StemSizeTo <= filterMushroomDto.StemSizeTo)
                    .ToList();
            }

            if (filterMushroomDto.StemType is not null)
            {
                mushrooms = mushrooms
                    .Where(mushroom => mushroom.StemType == filterMushroomDto.StemType)
                    .ToList();
            }

            if (filterMushroomDto.StemColor is not null)
            {
                mushrooms = mushrooms
                    .Where(mushroom => mushroom.StemColor == filterMushroomDto.StemColor)
                    .ToList();
            }

            var result = new List<(Mushroom, List<bool> DoppelgangersMap)>();
            foreach (var mushroom in mushrooms)
            {
                var doppelgangersMap = new List<bool>();
                foreach (var doppelganger in mushroom.Doppelgangers)
                {
                    try
                    {
                        await _mushroomsRepository.GetMushroomId(doppelganger.DoppelgangerName);

                        doppelgangersMap.Add(true);
                    }
                    catch (Exception)
                    {
                        doppelgangersMap.Add(false);
                    }
                }

                result.Add((mushroom, doppelgangersMap));
            }

            return result;
        }

        catch (Exception e)
        {
            throw new Exception($"Incorrect input data\nMessage: {e.Message}");
        }
    }

    // Creates a mushroom and doppelgangers for it in the database,
    // returns the id of the created mushroom
    public async Task<Guid> CreateMushroomAsync(Mushroom mushroom, CancellationToken ct)
    {
        try
        {
            await _mushroomsRepository.GetMushroomId(mushroom.Name);
            throw new Exception($"Mushroom \"{mushroom.Name}\" has already existed");
        }
        catch (Exception e)
        {
            if (e.Message == $"Mushroom \"{mushroom.Name}\" has already existed")
            {
                throw new Exception($"Unable to create mushroom \"{mushroom.Name}\": \"{e.Message}\"");
            }

            try
            {
                var createdMushroomId = await _mushroomsRepository.CreateMushroom(mushroom);

                return createdMushroomId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to create mushroom \"{mushroom.Name}\": \"{ex.Message}\"");
            }
        }
    }

    // Changes the mushroom parameters to new ones, returns the id of the changed mushroom
    public async Task<Guid> UpdateMushroomAsync(string mushroomName, Mushroom newMushroomModel, CancellationToken ct)
    {
        try
        {
            var existedMushroomId = await _mushroomsRepository.GetMushroomId(mushroomName);

            var updatedMushroomId = await _mushroomsRepository
                .UpdateMushroom(existedMushroomId, newMushroomModel);

            return updatedMushroomId;
        }
        catch (Exception e)
        {
            throw new Exception($"Unable to update mushroom \"{mushroomName}\": \"{e.Message}\"");
        }
    }

    // Deletes a mushroom and returns its id
    public async Task<Guid> DeleteMushroomAsync(string mushroomName, CancellationToken ct)
    {
        try
        {
            var mushroomId = await _mushroomsRepository.GetMushroomId(mushroomName);

            var deletedMushroomId = await _mushroomsRepository.DeleteMushroom(mushroomId);

            return deletedMushroomId;
        }
        catch (Exception e)
        {
            throw new Exception($"Unable to delete mushroom \"{mushroomName}\": \"{e.Message}\"");
        }
    }
}