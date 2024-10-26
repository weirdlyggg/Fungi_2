using BackendFungi.Models;

namespace BackendFungi.Abstractions;

public interface IMushroomsRepository
{
    Task<Guid> CreateMushroom(Mushroom mushroom);
    Task<List<Mushroom>> GetAllMushrooms();
    Task<Guid> GetMushroomId(string mushroomName);
    Task<Mushroom> GetMushroom(Guid mushroomId);
    Task<Guid> UpdateMushroom(Guid mushroomId, Mushroom newMushroomModel);
    Task<Guid> DeleteMushroom(Guid mushroomId);
}