﻿using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;

namespace CharacterSheeet.Core;

internal class SaveLayout : AbsoluteLayout
{
    Label _nameLabel;
    Label _saveLabel;
    Label _valueLabel;
    Circle _valueCircle;

    public SaveLayout(string name, string value, int left, int top)
        : base(left, top, 120, 60)
    {
        var smallFont = new Font12x16();
        var largeFont = new Font16x24();

        _nameLabel = new Label(0, 0, 120, 30)
        {
            BackColor = Color.Black,
            TextColor = Color.White,
            Font = smallFont,
            VerticalAlignment = VerticalAlignment.Bottom,
            HorizontalAlignment = HorizontalAlignment.Right,
            Text = name
        };
        _saveLabel = new Label(0, 30, 120, 30)
        {
            BackColor = Color.Black,
            TextColor = Color.White,
            Font = smallFont,
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Right,
            Text = "Save"
        };
        _valueLabel = new Label(0, 0, 60, 60)
        {
            BackColor = Color.Transparent,
            TextColor = Color.Black,
            Font = largeFont,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Text = value
        };
        _valueCircle = new Circle(34, 30, 25)
        {
            ForeColor = Color.White,
            IsFilled = true
        };

        this.Controls.Add(_nameLabel, _saveLabel, _valueCircle, _valueLabel);
    }

    public void SetValue(int value)
    {
        _valueLabel.Text = $"{value}:+#;-#";
    }
}
