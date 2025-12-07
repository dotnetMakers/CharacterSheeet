using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

public interface IActivatable : ISelectable
{
    /// <summary>
    /// Gets or sets whether the control is activated for editing.
    /// </summary>
    bool IsActivated { get; set; }
}

internal class ActivatableLabel : Label, IActivatable
{
    private bool _isActivated = false;

    public ActivatableLabel(int width, int height, string text = nameof(Label))
        : this(0, 0, width, height, ScaleFactor.X1, text)
    { }

    public ActivatableLabel(int width, int height, ScaleFactor scaleFactor = ScaleFactor.X1, string text = nameof(Label))
        : this(0, 0, width, height, scaleFactor, text)
    { }

    public ActivatableLabel(int left, int top, int width, int height, ScaleFactor scaleFactor = ScaleFactor.X1, string text = nameof(Label))
    : base(left, top, width, height, scaleFactor, text)
    {
    }

    /// <summary>
    /// Gets or sets whether the control is activated for editing.
    /// </summary>
    public bool IsActivated
    {
        get => _isActivated;
        set => SetInvalidatingProperty(ref _isActivated, value);
    }

    protected override void OnDraw(MicroGraphics graphics)
    {
        if (IsActivated)
        {
            DrawActivated(graphics);
            return;
        }

        base.OnDraw(graphics);
    }

    private void DrawActivated(MicroGraphics graphics)
    {
        // Invert colors
        Color textColor = BackgroundColor != Color.Transparent ? BackgroundColor : Color.White;
        Color backgroundColor = TextColor;

        graphics.DrawRectangle(ScreenLeft, ScreenTop, Width, Height, backgroundColor, true);

        var xOffset = HorizontalAlignment switch
        {
            HorizontalAlignment.Center => Width / 2,
            HorizontalAlignment.Right => Width,
            _ => 0,
        };
        var yOffset = VerticalAlignment switch
        {
            VerticalAlignment.Center => Height / 2,
            VerticalAlignment.Bottom => Height,
            _ => 0,
        };

        graphics.DrawText(
            ScreenLeft + xOffset,
            ScreenTop + yOffset,
            Text,
            textColor,
            scaleFactor: this.ScaleFactor,
            alignmentH: HorizontalAlignment,
            alignmentV: VerticalAlignment,
            font: Font);
    }
}
