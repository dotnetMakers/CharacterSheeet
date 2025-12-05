using CharacterSheeet.Dcc;
using Meadow.Foundation.Graphics.MicroLayout;

using Constants = CharacterSheeet.Dcc.LayoutConstants;

namespace CharacterSheeet.Core;

internal class AttributeCollectionLayout : AbsoluteLayout
{
    public AttributeCollectionLayout(int left, int top, Character character)
        : base(left, top, 60, Constants.AttributeBlockHeight * 6)
    {
        var strength = new AttributeLayout("Strength", 0, 0,
            character.Strength, character.GetAbilityModifier(character.Strength));
        var agility = new AttributeLayout("Agility", 0, Constants.AttributeBlockHeight,
            character.Agility, character.GetAbilityModifier(character.Agility));
        var stamina = new AttributeLayout("Stamina", 0, Constants.AttributeBlockHeight * 2,
            character.Stamina, character.GetAbilityModifier(character.Stamina));
        var personality = new AttributeLayout("Personality", 0, Constants.AttributeBlockHeight * 3,
            character.Personality, character.GetAbilityModifier(character.Personality));
        var luck = new AttributeLayout("Luck", 0, Constants.AttributeBlockHeight * 4,
            character.Luck, character.GetAbilityModifier(character.Luck));
        var intelligence = new AttributeLayout("intelligence", 0, Constants.AttributeBlockHeight * 5,
            character.Intelligence, character.GetAbilityModifier(character.Intelligence));

        Controls.Add(strength, agility, stamina, personality, luck, intelligence);

        character.PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case nameof(Character.Strength):
                        strength.SetValue(character.Strength, character.GetAbilityModifier(character.Strength));
                        break;
                    case nameof(Character.Agility):
                        strength.SetValue(character.Agility, character.GetAbilityModifier(character.Agility));
                        break;
                    case nameof(Character.Stamina):
                        strength.SetValue(character.Stamina, character.GetAbilityModifier(character.Stamina));
                        break;
                    case nameof(Character.Personality):
                        strength.SetValue(character.Personality, character.GetAbilityModifier(character.Personality));
                        break;
                    case nameof(Character.Luck):
                        strength.SetValue(character.Luck, character.GetAbilityModifier(character.Luck));
                        break;
                    case nameof(Character.Intelligence):
                        strength.SetValue(character.Intelligence, character.GetAbilityModifier(character.Intelligence));
                        break;
                }
            };
    }

}
