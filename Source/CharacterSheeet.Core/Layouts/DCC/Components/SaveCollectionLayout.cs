using CharacterSheeet.Dcc;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

internal class AttributeCollectionLayout : AbsoluteLayout
{
    public AttributeCollectionLayout(int left, int top, Character character)
        : base(left, top, 60, 65 * 6)
    {
        var strength = new AttributeLayout("Strength", left, top + 0,
            character.Strength, character.GetAbilityModifier(character.Strength));
        var agility = new AttributeLayout("Agility", left, top + 65,
            character.Agility, character.GetAbilityModifier(character.Agility));
        var stamina = new AttributeLayout("Stamina", left, top + 65 * 2,
            character.Stamina, character.GetAbilityModifier(character.Stamina));
        var personality = new AttributeLayout("Personality", left, top + 65 * 3,
            character.Personality, character.GetAbilityModifier(character.Personality));
        var luck = new AttributeLayout("Luck", left, top + 65 * 4,
            character.Luck, character.GetAbilityModifier(character.Luck));
        var intelligence = new AttributeLayout("intelligence", left, top + 65 * 5,
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

internal class SaveCollectionLayout : AbsoluteLayout
{
    public SaveCollectionLayout(int left, int top, Character character)
        : base(left, top, 340, 65 * 5 + 60)
    {
        var saves = character.GetCalculatedSaves();

        var refs = new SaveLayout("Ref", $"{saves.Ref:+#;-#;+0}", left, top);
        var fort = new SaveLayout("Fort", $"{saves.Fort:+#;-#;+0}", left, top + 65);
        var will = new SaveLayout("Will", $"{saves.Will:+#;-#;+0}", left, top + 65 * 2);

        this.Controls.Add(refs, fort, will);

        character.PropertyChanged += (s, e) =>
        {
            switch (e.PropertyName)
            {
                case nameof(Character.Agility):
                case nameof(Character.Stamina):
                case nameof(Character.Personality):
                case nameof(Character.Level):
                    var saves = character.GetCalculatedSaves();
                    refs.SetValue(saves.Ref);
                    fort.SetValue(saves.Fort);
                    will.SetValue(saves.Will);
                    break;
            }
        };

    }
}
