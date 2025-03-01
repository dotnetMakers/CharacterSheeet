namespace CharacterSheeet.Dcc;

public static class CharacterGenerator
{
    public static Halfling GenerateHalfling()
    {
        return new Halfling
        {
            Name = "Shorty",
            Occcupation = "Farmer",
            Alignment = "Lawful",
            Level = 1,
            XP = 10,
            MaxHitPoints = 5,
            CurrentHitPoints = 5,
            Strength = 13,
            Agility = 11,
            Stamina = 10,
            Personality = 4,
            Luck = 9,
            Intelligence = 6,
            Languages = ["common"],
            LuckyRoll = "Birdsong"
        };
    }
}
