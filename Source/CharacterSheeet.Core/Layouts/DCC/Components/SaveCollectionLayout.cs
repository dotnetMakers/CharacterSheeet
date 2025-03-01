using CharacterSheeet.Dcc;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

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
