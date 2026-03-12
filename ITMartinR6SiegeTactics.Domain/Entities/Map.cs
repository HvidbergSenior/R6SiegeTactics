namespace ITMartinR6SiegeTactics.Domain.Entities;

public class Map
{
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;  // new
    public List<BombSite> BombSites { get; set; } = new List<BombSite>();
}