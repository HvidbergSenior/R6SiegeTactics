using System.Net.Http.Json;
using ITMartinR6SiegeTactics.Domain.Entities;
using ITMartinR6SiegeTactics.Domain.Interfaces;

namespace ITMartinR6SiegeTactics.InfraStructure.Repositories;

public class JsonMapRepository : IMapRepository
{
    private readonly HttpClient _http;

    public JsonMapRepository(HttpClient http)
    {
        _http = http;
    }

    public async Task<Map> GetMap(string mapName)
    {
        return await _http.GetFromJsonAsync<Map>($"data/{mapName}.json");
    }
    
    private readonly Dictionary<string, Map> _maps = new()
    {
        ["Clubhouse"] = new Map
        {
            Name = "Clubhouse",
            BombSites = new List<BombSite>
            {
                new BombSite
                {
                    Name = "A",
                    Attack = new Strategy { Steps = new List<string> { "Push Main", "Cover Lobby" }, Operators = new List<OperatorRecommendation>{ new OperatorRecommendation { Name="Ash", Role="Attacker", Reason="Fast entry" } }, Placements = new List<Placement>{ new Placement{ Description="Breach wall", Image="images/clubhouse_a1.png" } } },
                    Defense = new Strategy { Steps = new List<string> { "Hold A" }, Operators = new List<OperatorRecommendation>(), Placements = new List<Placement>() }
                }
            }
        },
        ["Fortress"] = new Map
        {
            Name = "Fortress",
            BombSites = new List<BombSite>
            {
                new BombSite
                {
                    Name = "A",
                    Attack = new Strategy { Steps = new List<string> { "Enter Garage", "Take Control" }, Operators = new List<OperatorRecommendation>(), Placements = new List<Placement>() },
                    Defense = new Strategy { Steps = new List<string> { "Reinforce Vault" }, Operators = new List<OperatorRecommendation>(), Placements = new List<Placement>() }
                }
            }
        }
    };
}