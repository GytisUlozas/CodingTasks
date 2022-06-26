namespace Platformer.Models;

public class Platform
{
    public int Index { get; set; }
    public int Cost { get; set; }
    public bool Locked { get; set; }
    public bool? CurrentlyAccesible { get; set; }
}

