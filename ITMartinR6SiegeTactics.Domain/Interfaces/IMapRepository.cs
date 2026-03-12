using ITMartinR6SiegeTactics.Domain.Entities;

namespace ITMartinR6SiegeTactics.Domain.Interfaces;

public interface IMapRepository
{
    Task<Map> GetMap(string mapName);
}