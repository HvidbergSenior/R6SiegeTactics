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
            "Clubhouse" => Task.FromResult(ClubhouseMap()),
            "Fortress" => Task.FromResult(FortressMap()),
            _ => throw new ArgumentException($"Map '{mapName}' not found")
        };
    }

    private Map ClubhouseMap()
    {
        return new Map
        {
            Name = "Clubhouse",
            Image = "clubhouse.jpg",
            BombSites = new List<BombSite>
            {
                new BombSite
                {
                    Name = "A",
                    Attack = new Strategy
                    {
                        Steps = new List<string> { "Step 1: Enter Garage", "Step 2: Breach wall" },
                        Operators = new List<OperatorRecommendation>
                        {
                            new OperatorRecommendation { Name = "Sledge", Role = "Attacker", Reason = "Break walls quickly", Image = "sledge.jpg" },
                            new OperatorRecommendation { Name = "Ash", Role = "Attacker", Reason = "Ranged breaching", Image = "ash.jpg" }
                        },
                        Placements = new List<Placement>
                        {
                            new Placement { Description = "Breach wall near objective", Image = "clubhouse_a_attack.jpg" }
                        }
                    },
                    Defense = new Strategy
                    {
                        Steps = new List<string> { "Step 1: Hold site", "Step 2: Use Mira mirrors" },
                        Operators = new List<OperatorRecommendation>
                        {
                            new OperatorRecommendation { Name = "Kaid", Role = "Defender", Reason = "Stop electronics", Image = "kaid.jpg" },
                            new OperatorRecommendation { Name = "Mira", Role = "Defender", Reason = "Cover hallway", Image = "mira.jpg" }
                        },
                        Placements = new List<Placement>
                        {
                            new Placement { Description = "Place Mira mirror on wall", Image = "clubhouse_a_defense.jpg" }
                        }
                    }
                }
            }
        };
    }

    private Map FortressMap()
    {
        return new Map
        {
            Name = "Fortress",
            Image = "fortress.jpg",
            BombSites = new List<BombSite>
            {
                new BombSite
                {
                    Name = "A",
                    Attack = new Strategy
                    {
                        Steps = new List<string> { "Step 1 Attack Fortress" },
                        Operators = new List<OperatorRecommendation>
                        {
                            new OperatorRecommendation { Name = "Ash", Role = "Attacker", Reason = "Fast entry", Image = "ash.jpg" }
                        },
                        Placements = new List<Placement>
                        {
                            new Placement { Description = "Breach main wall", Image = "fortress_a_attack.jpg" }
                        }
                    },
                    Defense = new Strategy
                    {
                        Steps = new List<string> { "Step 1 Defend Fortress" },
                        Operators = new List<OperatorRecommendation>
                        {
                            new OperatorRecommendation { Name = "Smoke", Role = "Defender", Reason = "Block entry", Image = "smoke.jpg" }
                        },
                        Placements = new List<Placement>
                        {
                            new Placement { Description = "Place barbed wire", Image = "fortress_a_defense.jpg" }
                        }
                    }
                },
                
                new BombSite
                {
                    Name = "B",
                    Attack = new Strategy
                    {
                        Steps = new List<string> { "Step 1 Attack B" },
                        Operators = new List<OperatorRecommendation>
                        {
                            new OperatorRecommendation { Name = "Thermite", Role = "Attacker", Reason = "Open reinforced wall", Image = "thermite.jpg" }
                        },
                        Placements = new List<Placement>
                        {
                            new Placement { Description = "Breach wall", Image = "fortress_b_attack.jpg" }
                        }
                    },
                    Defense = new Strategy
                    {
                        Steps = new List<string> { "Step 1 Defend B" },
                        Operators = new List<OperatorRecommendation>
                        {
                            new OperatorRecommendation { Name = "Jäger", Role = "Defender", Reason = "Stop grenades", Image = "jager.jpg" }
                        },
                        Placements = new List<Placement>
                        {
                            new Placement { Description = "Place ADS", Image = "fortress_b_defense.jpg" }
                        }
                    }
                }
            }
        };
    }
}