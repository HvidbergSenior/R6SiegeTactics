namespace ITMartinR6SiegeTactics.Domain.Entities;

public class BombSite
{
    public string Name { get; set; } = string.Empty;
    public Strategy Attack { get; set; } = new Strategy();
    public Strategy Defense { get; set; } = new Strategy();
    public bool IsTop { get; set; } = true;
}