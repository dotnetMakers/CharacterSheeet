using CharacterSheeet.Core;
using CharacterSheeet.Core.Contracts;
using Meadow;
using Meadow.Foundation.Sensors.Buttons;
using Meadow.Foundation.Sensors.Hid;
using Meadow.Hardware;
using Meadow.Peripherals.Displays;
using Meadow.Peripherals.Sensors.Buttons;

namespace CharacterSheeet.DT;

internal class CharacterSheeetHardware : ICharacterSheeetHardware
{
    private readonly Desktop device;
    private readonly Keyboard keyboard;

    public RotationType DisplayRotation => RotationType.Default;
    public INetworkController? NetworkController { get; }
    public IPixelDisplay? Display => device.Display;
    public IButton? RightButton { get; }
    public IButton? LeftButton { get; }
    public IButton? UpButton { get; }
    public IButton? DownButton { get; }
    public IButton? CenterButton { get; }

    public CharacterSheeetHardware(Desktop device)
    {
        // var dis = new Epd7in5V2
        if (device.Display is IResizablePixelDisplay r)
        {
            r.Resize(480, 800, 1);
        }

        this.device = device;

        keyboard = new Keyboard();
        NetworkController = new NetworkController(keyboard);

        LeftButton = new PushButton(keyboard.Pins.Left.CreateDigitalInterruptPort(InterruptMode.EdgeFalling));
        RightButton = new PushButton(keyboard.Pins.Right.CreateDigitalInterruptPort(InterruptMode.EdgeFalling));
        UpButton = new PushButton(keyboard.Pins.Up.CreateDigitalInterruptPort(InterruptMode.EdgeFalling));
        DownButton = new PushButton(keyboard.Pins.Down.CreateDigitalInterruptPort(InterruptMode.EdgeFalling));
        CenterButton = new PushButton(keyboard.Pins.Space.CreateDigitalInterruptPort(InterruptMode.EdgeFalling));
    }
}