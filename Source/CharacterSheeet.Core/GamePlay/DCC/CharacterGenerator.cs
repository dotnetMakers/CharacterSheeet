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
            LuckyRoll = "Birdsong",
            Weapons = [
                new MeleeWeapon {  Name = "short sword", Damage = new Die(6)},
                new MeleeWeapon {  Name = "short sword", Damage = new Die(6)},
                new MissileWeapon {  Name = "crossbow", Damage = new Die(6)},
            ],
            Armor = new Armor { Name = "Padded", ACBonus = 1, CheckPenalty = 0, FumbleDie = new Die(4) },
            Equipment = [new Item { Name = "Torch", Quantity = 5 }, new Item { Name = "Rope, 50'" }, new Item { Name = "Rations, per day", Quantity = 3 }],
            Treasure = [new Treasure { Name = "gp", Quantity = 3 }, new Treasure { Name = "cp", Quantity = 15 }]
        };
    }
}
