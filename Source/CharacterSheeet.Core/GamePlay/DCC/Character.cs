using System;
using System.ComponentModel;

namespace CharacterSheeet.Dcc;

public abstract class Character : INotifyPropertyChanged
{
    private int _currentHP;

    public event PropertyChangedEventHandler? PropertyChanged;

    public virtual int BaseSpeed { get; } = 30;

    public abstract string Class { get; }
    public abstract string Title { get; }

    public string Name { get; set; }
    public string Occcupation { get; set; }
    public string Alignment { get; set; }
    public int Level { get; set; }
    public int XP { get; set; }

    public int CurrentHitPoints
    {
        get => _currentHP;
        set => this.SetAndRaiseIfChanged(ref _currentHP, value, args => PropertyChanged?.Invoke(this, args));
    }
    public int MaxHitPoints { get; set; }

    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Stamina { get; set; }
    public int Personality { get; set; }
    public int Luck { get; set; }
    public int Intelligence { get; set; }

    public string[] Languages { get; set; }

    public Weapon[] Weapons { get; set; }
    public Armor Armor { get; set; }
    public Item[] Equipment { get; set; }
    public Treasure[] Treasure { get; set; }

    public int Speed => BaseSpeed; // todo: add armor, etc
    public int InitiativeModifier => GetAbilityModifier(Agility); // fighters add another +1

    public abstract CombatBasics GetCombatBasics();

    public int ArmorClass
    {
        get
        {
            // TODO: add in armor, equipment, etc
            return 10 + GetAbilityModifier(Agility);
        }
    }

    public (int Ref, int Fort, int Will) GetCalculatedSaves()
    {
        var basics = GetCombatBasics();
        return (
            basics.ReflexSaveModifier + GetAbilityModifier(Agility),
            basics.FortitudeSaveModifier + GetAbilityModifier(Stamina),
            basics.WillpowerSaveModifier + GetAbilityModifier(Personality));
    }

    public (int MeleeAttack, int MeleeDamage, int MissileAttack, int MissileDamage) GetCombatModifiers()
    {
        var basics = GetCombatBasics();

        return (
            basics.AttackModifier + GetAbilityModifier(Strength),
            GetAbilityModifier(Strength),
            basics.AttackModifier + GetAbilityModifier(Agility),
            GetAbilityModifier(Agility)
            );
    }

    public int GetAbilityModifier(int abilityScore)
    {
        return abilityScore switch
        {
            3 => -3,
            4 or 5 => -2,
            >= 6 and <= 8 => -1,
            >= 9 and <= 12 => 0,
            >= 13 and <= 15 => 1,
            16 or 17 => 2,
            18 => 3,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
