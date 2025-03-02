namespace CharacterSheeet.Dcc;

public class Armor : Item
{
    public int ACBonus { get; set; }
    public int CheckPenalty { get; set; }
    public int SpeedPenalty { get; set; }
    public Die FumbleDie { get; set; }
}
