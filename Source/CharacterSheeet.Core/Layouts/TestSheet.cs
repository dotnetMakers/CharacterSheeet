using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;
using System.Collections.Generic;

namespace CharacterSheeet.Core;

internal class TestSheet : Sheet
{
    public TestSheet()
        : base(GenerateLayouts())
    {
    }

    private static IEnumerable<MicroLayout> GenerateLayouts()
    {
        return new MicroLayout[]
        {
            GeneratePage1(),
            GeneratePage2(),
        };
    }

    private static MicroLayout GeneratePage1()
    {
        var layout = new AbsoluteLayout(300, 300);

        var largeFont = new Font16x24();

        layout.Controls.Add(
            new Label(10, 10, 250, 30)
            {
                TextColor = Color.White,
                BackColor = Color.Black,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Font = largeFont,
                Text = $"This is Page 1"
            });

        return layout;
    }

    private static MicroLayout GeneratePage2()
    {
        var layout = new AbsoluteLayout(480, 480);

        var largeFont = new Font16x24();

        layout.Controls.Add(
            new Label(0, 0, 200, 30)
            {
                TextColor = Color.White,
                BackColor = Color.Black,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Font = largeFont,
                Text = $"This is Page 2"
            });

        return layout;
    }
}
