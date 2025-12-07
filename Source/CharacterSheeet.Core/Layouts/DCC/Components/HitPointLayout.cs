using CharacterSheeet.Core;
using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Dcc;

internal class HitPointLayout : AbsoluteLayout
{
    private readonly Character _character;
    private readonly Label _staticLabel;
    private readonly Label _maxLabel;
    private readonly ActivatableLabel _valueLabel;
    private readonly Picture _graphic;

    /// <summary>
    /// Gets the value label for selection management
    /// </summary>
    public ActivatableLabel ValueLabel => _valueLabel;

    public HitPointLayout(int left, int top, Character character, int selectionIndex = -1)
        : base(left, top, 120, 150)
    {
        var img = Image.LoadFromResource("CharacterSheeet.Core.Assets.cup.bmp");

        _graphic = new Picture(15, 0, 90, 113, img);

        _staticLabel = new Label(0, 120, this.Width, 15)
        {
            BackgroundColor = Color.White,
            TextColor = Color.Black,
            Font = LayoutConstants.SmallFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = "Hit Points"
        };
        _maxLabel = new Label(0, _staticLabel.Bottom, this.Width, 15)
        {
            BackgroundColor = Color.White,
            TextColor = Color.Black,
            Font = LayoutConstants.SmallFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = $"Max: {character.MaxHitPoints}"
        };
        _valueLabel = new ActivatableLabel((this.Width - 50) / 2, 50, 50, 28)
        {
            BackgroundColor = Color.White,
            TextColor = Color.Black,
            Font = LayoutConstants.LargeFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = character.CurrentHitPoints.ToString(),
            IsSelectable = selectionIndex >= 0,
            SelectionIndex = selectionIndex
        };

        _character = character;

        this.Controls.Add(_graphic, _staticLabel, _maxLabel, _valueLabel);

        character.PropertyChanged += (s, e) =>
        {
            switch (e.PropertyName)
            {
                case nameof(Character.MaxHitPoints):
                    _maxLabel.Text = $"Max: {character.MaxHitPoints}";
                    break;
                case nameof(Character.CurrentHitPoints):
                    _valueLabel.Text = character.CurrentHitPoints.ToString();
                    break;
            }
        };
    }

    /// <summary>
    /// Increments the current hit points
    /// </summary>
    public void IncrementValue()
    {
        if (_character.CurrentHitPoints < _character.MaxHitPoints)
        {
            _character.CurrentHitPoints++;
        }
    }

    /// <summary>
    /// Decrements the current hit points
    /// </summary>
    public void DecrementValue()
    {
        if (_character.CurrentHitPoints > 0)
        {
            _character.CurrentHitPoints--;
        }
    }
}
