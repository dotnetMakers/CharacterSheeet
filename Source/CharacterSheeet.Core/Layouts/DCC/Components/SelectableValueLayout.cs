using CharacterSheeet.Dcc;
using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

/// <summary>
/// Example layout showing a selectable value with label and value display.
/// </summary>
public class SelectableValueLayout : AbsoluteLayout
{
    private readonly Label _titleLabel;
    private readonly Label _valueLabel;

    public string Title
    {
        get => _titleLabel.Text;
        set => _titleLabel.Text = value;
    }

    public string Value
    {
        get => _valueLabel.Text;
        set => _valueLabel.Text = value;
    }

    public int SelectionIndex
    {
        get => _valueLabel.SelectionIndex;
        set => _valueLabel.SelectionIndex = value;
    }

    public bool IsSelectable
    {
        get => _valueLabel.IsSelectable;
        set => _valueLabel.IsSelectable = value;
    }

    public Label ValueLabel => _valueLabel;

    /// <summary>
    /// Creates a new selectable value layout.
    /// </summary>
    /// <param name="x">X position</param>
    /// <param name="y">Y position</param>
    /// <param name="width">Total width</param>
    /// <param name="height">Total height</param>
    /// <param name="title">Title text</param>
    /// <param name="value">Initial value</param>
    /// <param name="selectionIndex">Selection index for navigation</param>
    public SelectableValueLayout(int x, int y, int width, int height,
        string title, string value, int selectionIndex = -1)
        : base(x, y, width, height)
    {
        // Title label (not selectable)
        _titleLabel = new Label(0, 0, width, height / 2)
        {
            Text = title,
            TextColor = Color.Black,
            BackgroundColor = Color.Transparent,
            Font = LayoutConstants.MediumFont,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Center
        };

        // Value label (selectable)
        _valueLabel = new Label(0, height / 2, width, height / 2)
        {
            Text = value,
            TextColor = Color.Black,
            BackgroundColor = Color.White,
            Font = LayoutConstants.MediumFont,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            IsSelectable = selectionIndex >= 0,
            SelectionIndex = selectionIndex
        };

        Controls.Add(_titleLabel, _valueLabel);
    }
}
