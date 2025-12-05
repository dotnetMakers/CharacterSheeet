using CharacterSheeet.Core;
using CharacterSheeet.Core.Contracts;
using Meadow;
using Meadow.Devices;
using Meadow.Foundation.Displays;
using Meadow.Foundation.Sensors.Buttons;
using Meadow.Foundation.Sensors.Motion;
using Meadow.Peripherals.Displays;
using Meadow.Peripherals.Sensors.Buttons;
using System.Threading.Tasks;

namespace CharacterSheeet.F7;

internal class CharacterSheeetF7FeatherHardware : ICharacterSheeetHardware
{
    public RotationType DisplayRotation => RotationType._90Degrees;
    public IButton? RightButton { get; }
    public IButton? LeftButton { get; }
    public IButton? UpButton { get; }
    public IButton? DownButton { get; }
    public IButton? CenterButton { get; }

    public IPixelDisplay? Display { get; }
    public INetworkController NetworkController { get; }

    private readonly Apds9960 _gestureSensor;

    public CharacterSheeetF7FeatherHardware(F7FeatherBase device)
    {
        NetworkController = new NetworkController(device);

        Display = new Epd7in5V2(
            device.CreateSpiBus(),
            device.Pins.D00, //CS
            device.Pins.D01, // DC
            device.Pins.D02, // RST
            device.Pins.D03  // BUSY
            );

        //        LeftButton = new PushButton(device.Pins.D14, Meadow.Hardware.ResistorMode.InternalPullDown);
        RightButton = new PushButton(device.Pins.D12, Meadow.Hardware.ResistorMode.InternalPullDown);
        UpButton = new PushButton(device.Pins.D13, Meadow.Hardware.ResistorMode.InternalPullDown);
        //DownButton = new PushButton(device.Pins.D11, Meadow.Hardware.ResistorMode.InternalPullDown);
        //        CenterButton = new PushButton(device.Pins.D15, Meadow.Hardware.ResistorMode.InternalPullDown);

        _gestureSensor = new Apds9960(device.CreateI2cBus(), device.Pins.D04);

        _ = GestureWatcher();
    }

    private async Task GestureWatcher()
    {
        while (true)
        {
            if (_gestureSensor.IsGestureAvailable())
            {
                var g = _gestureSensor.ReadGesture();
                Resolver.Log.Info($"Gesture: {g}");
            }

            await Task.Delay(1000);
        }
    }
}