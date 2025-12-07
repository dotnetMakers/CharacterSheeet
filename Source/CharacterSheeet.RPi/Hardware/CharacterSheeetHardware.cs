using CharacterSheeet.Core;
using CharacterSheeet.Core.Contracts;
using Meadow;
using Meadow.Foundation.Displays;
using Meadow.Peripherals.Displays;
using Meadow.Peripherals.Sensors;
using Meadow.Peripherals.Sensors.Buttons;
using Meadow.Units;

namespace CharacterSheeet.RPi;

internal class CharacterSheeetHardware : ICharacterSheeetHardware
{
    private readonly RaspberryPi device;
    private readonly ITemperatureSensor temperatureSimulator;

    public RotationType DisplayRotation => RotationType._90Degrees;
    public IPixelDisplay? Display { get; }
    public INetworkController NetworkController { get; }
    public ITemperatureSensor? TemperatureSensor => temperatureSimulator;
    public IButton? RightButton { get; }
    public IButton? LeftButton { get; }
    public IButton? UpButton { get; }
    public IButton? DownButton { get; }
    public IButton? CenterButton { get; }

    public CharacterSheeetHardware(RaspberryPi device)
    {
        this.device = device;

        Display = new Epd7in5V2(
            device.CreateSpiBus(0, 4000000.Hertz()),
            device.Pins.Pin24, //CS
            device.Pins.Pin22, // DC
            device.Pins.Pin11, // RST
            device.Pins.Pin18  // BUSY
            );
    }
}