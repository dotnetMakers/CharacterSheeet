using CharacterSheeet.Dcc;
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

    private static IEnumerable<ILayout> GenerateLayouts()
    {
        return new ILayout[]
        {
            GeneratePage1(),
            GeneratePage2(),
        };
    }

    private static ILayout GeneratePage1()
    {
        var layout = new AbsoluteLayout(300, 300);

        layout.Controls.Add(
            new Label(10, 10, 250, 30)
            {
                TextColor = Color.White,
                BackgroundColor = Color.Black,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Font = LayoutConstants.LargeFont,
                Text = $"This is Page 1"
            });

        return layout;
    }

    private static ILayout GeneratePage2()
    {
        var layout = new AbsoluteLayout(480, 480);

        layout.Controls.Add(
            new Label(0, 0, 200, 30)
            {
                TextColor = Color.White,
                BackgroundColor = Color.Black,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Font = LayoutConstants.LargeFont,
                Text = $"This is Page 2"
            });

        return layout;
    }
}
