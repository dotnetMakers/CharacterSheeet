using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

internal class CombatBasicsLayout : AbsoluteLayout
{
    Box _boundsBox;
    Label _titleLabel;

    Label _initiativeLabel;
    Label _initiativeValueLabel;
    Label _actionDiceLabel;
    Label _actionDiceValueLabel;
    private Label _attackLabel;
    private Label _attackValueLabel;
    private Label _critDieLabel;
    private Label _critDieValueLabel;
    private Label _critTableLabel;
    private Label _critTableValueLabel;

    public CombatBasicsLayout(int left, int top)
        : base(left, top, 210, 200)
    {
        var font = new Font8x16();

        _boundsBox = new Box(0, 0, this.Width, this.Height)
        {
            ForeColor = Color.Black,
            IsFilled = false
        };
        _titleLabel = new Label(0, 0, this.Width, 30)
        {
            TextColor = Color.White,
            BackColor = Color.Black,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            Font = font,
            Text = "Combat Basics"
        };

        _initiativeLabel = new Label(5, 32, 140, 30)
        {
            TextColor = Color.Black,
            BackColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Center,
            Font = font,
            Text = "Initiative:"
        };
        _initiativeValueLabel = new Label(130, 32, 70, 30)
        {
            TextColor = Color.Black,
            BackColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Center,
            Font = font,
            Text = "+1"
        };

        _actionDiceLabel = new Label(5, 60, 140, 30)
        {
            TextColor = Color.Black,
            BackColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Center,
            Font = font,
            Text = "Action Dice:"
        };
        _actionDiceValueLabel = new Label(130, 60, 70, 30)
        {
            TextColor = Color.Black,
            BackColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Center,
            Font = font,
            Text = "d16/d20"
        };

        _attackLabel = new Label(5, 90, 140, 30)
        {
            TextColor = Color.Black,
            BackColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Center,
            Font = font,
            Text = "Attack:"
        };
        _attackValueLabel = new Label(130, 90, 70, 30)
        {
            TextColor = Color.Black,
            BackColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Center,
            Font = font,
            Text = "+1/+2"
        };

        _critDieLabel = new Label(5, 120, 140, 30)
        {
            TextColor = Color.Black,
            BackColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Center,
            Font = font,
            Text = "Crit die:"
        };
        _critDieValueLabel = new Label(130, 120, 70, 30)
        {
            TextColor = Color.Black,
            BackColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Center,
            Font = font,
            Text = "d8"
        };

        _critTableLabel = new Label(5, 150, 140, 30)
        {
            TextColor = Color.Black,
            BackColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Center,
            Font = font,
            Text = "Crit table:"
        };
        _critTableValueLabel = new Label(130, 150, 70, 30)
        {
            TextColor = Color.Black,
            BackColor = Color.Transparent,
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Center,
            Font = font,
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
    }
}
