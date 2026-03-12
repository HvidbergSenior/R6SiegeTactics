namespace ITMartinR6SiegeTactics.Domain.Entities;

public class Strategy
{
    // Steps and placements
    public List<string> Steps { get; set; } = new();
    public List<Placement> Placements { get; set; } = new();

    // Operators
    public List<OperatorRecommendation> Operators { get; set; } = new();

    // Attack-specific
    public List<OperatorRecommendation> OperatorBanOrder { get; set; } = new();
    public List<string> DefaultCams { get; set; } = new();
    public List<string> SpawnPeeks { get; set; } = new();
    public List<string> RushOuts { get; set; } = new();

    // Defense-specific
    public List<OperatorRecommendation> NeedToHaveOperators { get; set; } = new();
    public List<OperatorRecommendation> NiceToHaveOperators { get; set; } = new();
    public List<OperatorRecommendation> FunToHaveOperators { get; set; } = new();
}