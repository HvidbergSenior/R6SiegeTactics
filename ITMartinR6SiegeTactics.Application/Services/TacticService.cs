using ITMartinR6SiegeTactics.Domain.Entities;
using ITMartinR6SiegeTactics.Domain.Interfaces;

namespace ITMartinR6SiegeTactics.Application.Services;

public class TacticService
{
    private readonly IMapRepository _mapRepository;

    public TacticService(IMapRepository mapRepository)
    {
        _mapRepository = mapRepository;
    }

    public Task<Map> GetMap(string mapName)
    {
        return mapName switch
        {
            "Clubhouse" => Task.FromResult(GenerateMap("Clubhouse")),
            "Coastline" => Task.FromResult(GenerateMap("Coastline")),
            "Oregon" => Task.FromResult(GenerateMap("Oregon")),
            "Kafe Dostoyevsky" => Task.FromResult(GenerateMap("Kafe Dostoyevsky")),
            "Bank" => Task.FromResult(GenerateMap("Bank")),
            "Villa" => Task.FromResult(GenerateMap("Villa")),
            "Border" => Task.FromResult(GenerateMap("Border")),
            "Consulate" => Task.FromResult(GenerateMap("Consulate")),
            "Chalet" => Task.FromResult(GenerateMap("Chalet")),
            "Nighthaven Labs" => Task.FromResult(GenerateMap("Nighthaven Labs")),
            "Skyscraper" => Task.FromResult(GenerateMap("Skyscraper")),
            "Theme Park" => Task.FromResult(GenerateMap("Theme Park")),
            "Kanal" => Task.FromResult(GenerateMap("Kanal")),
            "Lair" => Task.FromResult(GenerateMap("Lair")),
            "Emerald Plains" => Task.FromResult(GenerateMap("Emerald Plains")),
            "Outback" => Task.FromResult(GenerateMap("Outback")),
            _ => throw new ArgumentException($"Map '{mapName}' not found")
        };
    }

    private Map GenerateMap(string mapName)
    {
        var rnd = new Random();
        var operators = new[] { "Ash", "Fuze", "Kapkan", "Mira", "Thermite" };
        var bombsiteNames = new[] { "A", "B", "C", "D" };

        var sites = bombsiteNames.Select(site => new BombSite
        {
            Name = site,
            IsTop = true,
            Attack = new Strategy
            {
                Steps = new List<string> { $"Step 1 Attack {site}", $"Step 2 Attack {site}" },
                Operators = operators.OrderBy(x => rnd.Next()).Take(2)
                    .Select(op => new OperatorRecommendation { Name = op, Role = "Attacker", Image = $"{op.ToLower()}.png", Reason = "Random reason" }).ToList(),
                Placements = new List<Placement> { new Placement { Description = $"Attack placement for {site}", Image = $"{mapName.ToLower()}_{site.ToLower()}_attack.jpg" } },
                OperatorBanOrder = operators.OrderBy(x => rnd.Next()).Take(1)
                    .Select(op => new OperatorRecommendation { Name = op, Image = $"{op.ToLower()}.png" }).ToList(),
                DefaultCams = new List<string> { "cam1.jpg", "cam2.jpg" },
                SpawnPeeks = new List<string> { "spawn1.jpg" },
                RushOuts = new List<string> { "rush1.jpg" }
            },
            Defense = new Strategy
            {
                Steps = new List<string> { $"Step 1 Defend {site}", $"Step 2 Defend {site}" },
                Operators = operators.OrderBy(x => rnd.Next()).Take(2)
                    .Select(op => new OperatorRecommendation { Name = op, Role = "Defender", Image = $"{op.ToLower()}.png", Tip = $"Tip for {op}", TipImage = $"{op.ToLower()}_tip1.jpg", Reason = "Random reason" }).ToList(),
                Placements = new List<Placement> { new Placement { Description = $"Defense placement for {site}", Image = $"{mapName.ToLower()}_{site.ToLower()}_defense.jpg" } },
                NiceToHaveOperators = operators.OrderBy(x => rnd.Next()).Take(1)
                    .Select(op => new OperatorRecommendation { Name = op, Image = $"{op.ToLower()}.png" }).ToList(),
                NeedToHaveOperators = operators.OrderBy(x => rnd.Next()).Take(1)
                    .Select(op => new OperatorRecommendation { Name = op, Image = $"{op.ToLower()}.png" }).ToList(),
                FunToHaveOperators = operators.OrderBy(x => rnd.Next()).Take(1)
                    .Select(op => new OperatorRecommendation { Name = op, Image = $"{op.ToLower()}.png" }).ToList(),
                DefaultCams = new List<string> { "cam1.jpg", "cam2.jpg" }
            }
        }).ToList();

        return new Map { Name = mapName, Image = $"{mapName.ToLower().Replace(" ", "_")}.jpg", BombSites = sites };
    }
}