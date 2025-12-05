using CharacterSheeet.Dcc;
using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

internal class CombatBasicsLayout : AbsoluteLayout
{
    private readonly Character _character;

    private readonly Box _boundsBox;
    private readonly Label _titleLabel;

    private readonly Label _initiativeLabel;
    private readonly Label _initiativeValueLabel;
    private readonly Label _actionDiceLabel;
    private readonly Label _actionDiceValueLabel;
    private readonly Label _attackLabel;
    private readonly Label _attackValueLabel;
    private readonly Label _critDieLabel;
    private readonly Label _critDieValueLabel;
    private readonly Label _critTableLabel;
    private readonly Label _critTableValueLabel;

    public CombatBasicsLayout(int left, int top, Character character)
        : base(left, top, 210, 200)
    {
        _character = character;

        _boundsBox = new Box(0, 0, this.Width, this.Height)
        {
            ForegroundColor = Color.Black,
            IsFilled = false
        };
        _titleLabel = new Label(0, 0, this.Width, 30)
        {
            TextColor = Color.White,
            BackgroundColor = Color.Black,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            Font = LayoutConstants.XSmallFont,
            Text = "Combat Basics"
        };

        _initiativeLabel = new Label(5, 32, 140, 30)
        {
            TextColor = Color.Black,
            BackgroundColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Center,
            Font = LayoutConstants.XSmallFont,
            Text = "Initiative:"
        };
        _initiativeValueLabel = new Label(130, 32, 70, 30)
        {
            TextColor = Color.Black,
            BackgroundColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Center,
            Font = LayoutConstants.XSmallFont,
            Text = $"{character.InitiativeModifier:+#;-#}"
        };

        _actionDiceLabel = new Label(5, 60, 140, 30)
        {
            TextColor = Color.Black,
            BackgroundColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Center,
            Font = LayoutConstants.XSmallFont,
            Text = "Action Dice:"
        };
        _actionDiceValueLabel = new Label(130, 60, 70, 30)
        {
            TextColor = Color.Black,
            BackgroundColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Center,
            Font = LayoutConstants.XSmallFont,
            Text = "d16/d20"
        };

        _attackLabel = new Label(5, 90, 140, 30)
        {
            TextColor = Color.Black,
            BackgroundColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Center,
            Font = LayoutConstants.XSmallFont,
            Text = "Attack:"
        };
        _attackValueLabel = new Label(130, 90, 70, 30)
        {
            TextColor = Color.Black,
            BackgroundColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Center,
            Font = LayoutConstants.XSmallFont,
            Text = "+1/+2"
        };

        _critDieLabel = new Label(5, 120, 140, 30)
        {
            TextColor = Color.Black,
            BackgroundColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Center,
            Font = LayoutConstants.XSmallFont,
            Text = "Crit die:"
        };
        _critDieValueLabel = new Label(130, 120, 70, 30)
        {
            TextColor = Color.Black,
            BackgroundColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Center,
            Font = LayoutConstants.XSmallFont,
            Text = "d8"
        };

        _critTableLabel = new Label(5, 150, 140, 30)
        {
            TextColor = Color.Black,
            BackgroundColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Center,
            Font = LayoutConstants.XSmallFont,
            Text = "Crit table:"
        };
        _critTableValueLabel = new Label(130, 150, 70, 30)
        {
            TextColor = Color.Black,
            BackgroundColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Center,
            Font = LayoutConstants.XSmallFont,
            Text = "IV"
        };

        this.Controls.Add(
            _boundsBox, _titleLabel,
            _initiativeLabel, _initiativeValueLabel,
            _actionDiceLabel, _actionDiceValueLabel,
            _attackLabel, _attackValueLabel,
            _critDieLabel, _critDieValueLabel,
            _critTableLabel, _critTableValueLabel
            );

        Update();

        // TODO: update on level change
    }

    private void Update()
    {
        _initiativeValueLabel.Text = $"{_character.InitiativeModifier:+#;-#;+0}";
        var basics = _character.GetCombatBasics();
        _actionDiceValueLabel.Text = string.Join('+', (object[])basics.ActionDice);
        _attackValueLabel.Text = $"{basics.AttackModifier:+#;-#}";
        _critDieValueLabel.Text = $"{basics.CritDie}";
        _critTableValueLabel.Text = $"{basics.CritTable.ToRomanNumeral()}";
    }
}
