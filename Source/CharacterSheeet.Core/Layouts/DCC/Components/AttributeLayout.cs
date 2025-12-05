using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

internal class AttributeLayout : AbsoluteLayout
{
    private readonly Label _nameLabel;
    private readonly Label _modifierLabel;
    private readonly Label _valueLabel;
    private readonly Box _valueBox;
    private readonly string _attributeName;
    private int _currentValue;
    private int _currentModifier;

    /// <summary>
    /// Gets the value label for selection management
    /// </summary>
    public Label ValueLabel => _valueLabel;

    public AttributeLayout(string name, int left, int top, int value, int modifier, int selectionIndex = -1)
        : base(left, top, 210, 60)
    {
        var smallFont = new Font12x16();
        var largeFont = new Font16x24();

        _nameLabel = new Label(0, 0, 150, this.Height / 2)
        {
            BackgroundColor =Color.Black,
            TextColor = Color.White,
            Font = smallFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Left,
            Text = name
        };
        _modifierLabel = new Label(0, _nameLabel.Bottom, _nameLabel.Width, this.Height - _nameLabel.Height)
        {
            BackgroundColor =Color.White,
            TextColor = Color.Black,
            Font = smallFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Left
        };
        _valueBox = new Box(_nameLabel.Right, 0, this.Width - _nameLabel.Width, this.Height)
        {
            ForegroundColor = Color.Black,
            IsFilled = false
        };
        _valueLabel = new Label(_valueBox.Left + 2, _valueBox.Top + 2, _valueBox.Width - 4, _valueBox.Height - 4)
        {
            BackgroundColor = Color.White,
            TextColor = Color.Black,
            Font = largeFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            IsSelectable = selectionIndex >= 0,
            SelectionIndex = selectionIndex
        };

        _attributeName = name;
        this.Controls.Add(_nameLabel, _modifierLabel, _valueBox, _valueLabel);

        SetValue(value, modifier);
    }

    public void SetValue(int value, int modifier)
    {
        _currentValue = value;
        _currentModifier = modifier;
        _valueLabel.Text = value.ToString();
        _modifierLabel.Text = $"modifier: {modifier:+#;-#;+0}";
    }

    /// <summary>
    /// Gets the current attribute value
    /// </summary>
    public int Value => _currentValue;

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
        _valueLabel.Text = _currentValue.ToString();
        // Recalculate modifier based on DCC rules
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
