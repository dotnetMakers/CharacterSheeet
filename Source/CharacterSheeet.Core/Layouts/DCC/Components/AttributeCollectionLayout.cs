using CharacterSheeet.Dcc;
using Meadow.Foundation.Graphics.MicroLayout;

using Constants = CharacterSheeet.Dcc.LayoutConstants;

namespace CharacterSheeet.Core;

internal class AttributeCollectionLayout : AbsoluteLayout
{
    private readonly Character _character;
    private readonly AttributeLayout _strength;
    private readonly AttributeLayout _agility;
    private readonly AttributeLayout _stamina;
    private readonly AttributeLayout _personality;
    private readonly AttributeLayout _luck;
    private readonly AttributeLayout _intelligence;

    /// <summary>
    /// Gets all attribute layouts for selection management
    /// </summary>
    public AttributeLayout[] Attributes => new[]
    {
        _strength, _agility, _stamina, _personality, _luck, _intelligence
    };

    public AttributeCollectionLayout(int left, int top, Character character, int startingSelectionIndex = 2)
        : base(left, top, 60, Constants.AttributeBlockHeight * 6)
    {
        _character = character;

        _strength = new AttributeLayout("Strength", 0, 0,
            character.Strength, character.GetAbilityModifier(character.Strength), startingSelectionIndex + 0);
        _agility = new AttributeLayout("Agility", 0, Constants.AttributeBlockHeight,
            character.Agility, character.GetAbilityModifier(character.Agility), startingSelectionIndex + 1);
        _stamina = new AttributeLayout("Stamina", 0, Constants.AttributeBlockHeight * 2,
            character.Stamina, character.GetAbilityModifier(character.Stamina), startingSelectionIndex + 2);
        _personality = new AttributeLayout("Personality", 0, Constants.AttributeBlockHeight * 3,
            character.Personality, character.GetAbilityModifier(character.Personality), startingSelectionIndex + 3);
        _luck = new AttributeLayout("Luck", 0, Constants.AttributeBlockHeight * 4,
            character.Luck, character.GetAbilityModifier(character.Luck), startingSelectionIndex + 4);
        _intelligence = new AttributeLayout("Intelligence", 0, Constants.AttributeBlockHeight * 5,
            character.Intelligence, character.GetAbilityModifier(character.Intelligence), startingSelectionIndex + 5);

        // Wire up ValueChanged events to update character model
        _strength.ValueChanged += (s, v) => character.Strength = v;
        _agility.ValueChanged += (s, v) => character.Agility = v;
        _stamina.ValueChanged += (s, v) => character.Stamina = v;
        _personality.ValueChanged += (s, v) => character.Personality = v;
        _luck.ValueChanged += (s, v) => character.Luck = v;
        _intelligence.ValueChanged += (s, v) => character.Intelligence = v;

        Controls.Add(_strength, _agility, _stamina, _personality, _luck, _intelligence);

        character.PropertyChanged += (s, e) =>
        {
            switch (e.PropertyName)
            {
                case nameof(Character.Strength):
                    _strength.SetValue(character.Strength, character.GetAbilityModifier(character.Strength));
                    break;
                case nameof(Character.Agility):
                    _agility.SetValue(character.Agility, character.GetAbilityModifier(character.Agility));
                    break;
                case nameof(Character.Stamina):
                    _stamina.SetValue(character.Stamina, character.GetAbilityModifier(character.Stamina));
                    break;
                case nameof(Character.Personality):
                    _personality.SetValue(character.Personality, character.GetAbilityModifier(character.Personality));
                    break;
                case nameof(Character.Luck):
                    _luck.SetValue(character.Luck, character.GetAbilityModifier(character.Luck));
                    break;
                case nameof(Character.Intelligence):
                    _intelligence.SetValue(character.Intelligence, character.GetAbilityModifier(character.Intelligence));
                    break;
            }
        };
    }
}
