namespace ITMartinR6SiegeTactics.Domain.Entities;

public class Strategy
{
    public List<OperatorRecommendation> Operators { get; set; }
    public List<string> Steps { get; set; }
    public List<Placement> Placements { get; set; }
    public string RecommendedBan { get; set; } = string.Empty;
}