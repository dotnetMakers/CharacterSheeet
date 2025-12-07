using CharacterSheeet.Dcc;
using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

internal class AttributeLayout : AbsoluteLayout
{
    private readonly Label _nameLabel;
    private readonly Label _modifierLabel;
    private readonly ActivatableLabel _currentValueLabel;
    private readonly Label _normalValueLabel;
    private readonly Box _valueBox;
    private readonly string _attributeName;
    private int _currentValue;
    private readonly int _normalValue;
    private int _currentModifier;

    /// <summary>
    /// Gets the current value label for selection management
    /// </summary>
    public ActivatableLabel ValueLabel => _currentValueLabel;

    public AttributeLayout(string name, int left, int top, int normalValue, int currentValue, int modifier, int selectionIndex = -1)
        : base(left, top, 210, 60)
    {
        _nameLabel = new Label(0, 0, 150, this.Height / 2)
        {
            BackgroundColor = Color.Black,
            TextColor = Color.White,
            Font = LayoutConstants.SmallFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Left,
            Text = name
        };
        _modifierLabel = new Label(0, _nameLabel.Bottom, _nameLabel.Width, this.Height - _nameLabel.Height)
        {
            BackgroundColor = Color.White,
            TextColor = Color.Black,
            Font = LayoutConstants.SmallFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Left
        };
        _valueBox = new Box(_nameLabel.Right, 0, this.Width - _nameLabel.Width, this.Height)
        {
            ForegroundColor = Color.Black,
            IsFilled = false
        };

        // Current value - upper left, larger, selectable
        _currentValueLabel = new ActivatableLabel(_valueBox.Left + 4, _valueBox.Top + 2, 30, 28)
        {
            BackgroundColor = Color.White,
            TextColor = Color.Black,
            Font = LayoutConstants.LargeFont,
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Left,
            IsSelectable = selectionIndex >= 0,
            SelectionIndex = selectionIndex
        };

        // Normal value - lower right, smaller, not selectable
        _normalValueLabel = new Label(_valueBox.Right - 24, _valueBox.Bottom - 18, 20, 14)
        {
            BackgroundColor = Color.White,
            TextColor = Color.Black,
            Font = LayoutConstants.SmallFont,
            VerticalAlignment = VerticalAlignment.Bottom,
            HorizontalAlignment = HorizontalAlignment.Right
        };

        _attributeName = name;
        _normalValue = normalValue;

        this.Controls.Add(_nameLabel, _modifierLabel, _valueBox, _currentValueLabel, _normalValueLabel);

        SetValue(currentValue, modifier);
    }

    public void SetValue(int currentValue, int modifier)
    {
        _currentValue = currentValue;
        _currentModifier = modifier;
        _currentValueLabel.Text = currentValue.ToString();
        _normalValueLabel.Text = _normalValue.ToString();
        _modifierLabel.Text = $"modifier: {modifier:+#;-#;+0}";
    }

    /// <summary>
    /// Gets the current attribute value
    /// </summary>
    public int Value => _currentValue;

    /// <summary>
    /// Gets the normal (base) attribute value
    /// </summary>
    public int NormalValue => _normalValue;

    /// <summary>
    /// Event raised when the attribute value changes
    /// </summary>
    public event System.EventHandler<int>? ValueChanged;

    /// <summary>
    /// Increments the attribute value (max 18)
    /// </summary>
    public void IncrementValue()
    {
        if (_currentValue < 18)
        {
            _currentValue++;
            UpdateDisplay();
            ValueChanged?.Invoke(this, _currentValue);
        }
    }

    /// <summary>
    /// Decrements the attribute value (min 3)
    /// </summary>
    public void DecrementValue()
    {
        if (_currentValue > 3)
        {
            _currentValue--;
            UpdateDisplay();
            ValueChanged?.Invoke(this, _currentValue);
        }
    }

    private void UpdateDisplay()
    {
        _currentValueLabel.Text = _currentValue.ToString();
        // Recalculate modifier based on DCC rules (using current value)
        _currentModifier = _currentValue switch
        {
            3 => -3,
            4 or 5 => -2,
            >= 6 and <= 8 => -1,
            >= 9 and <= 12 => 0,
            >= 13 and <= 15 => 1,
            16 or 17 => 2,
            18 => 3,
            _ => 0
        };
        _modifierLabel.Text = $"modifier: {_currentModifier:+#;-#;+0}";
    }
}
