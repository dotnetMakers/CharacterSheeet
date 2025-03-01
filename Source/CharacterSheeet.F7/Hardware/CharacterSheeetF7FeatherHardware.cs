using CharacterSheeet.Core;
using CharacterSheeet.Core.Contracts;
using Meadow.Devices;
using Meadow.Foundation.Sensors;
using Meadow.Peripherals.Displays;
using Meadow.Peripherals.Sensors;
using Meadow.Peripherals.Sensors.Buttons;
using Meadow.Units;

namespace CharacterSheeet.F7;

internal class CharacterSheeetF7FeatherHardware : ICharacterSheeetHardware
{
    private readonly ITemperatureSensor temperatureSensor;

    public RotationType DisplayRotation => RotationType.Default;
    public ITemperatureSensor? TemperatureSensor => temperatureSensor;
    public IButton? RightButton => null;
    public IButton? LeftButton => null;
    public IPixelDisplay? Display => null;
    public INetworkController NetworkController { get; }

    public CharacterSheeetF7FeatherHardware(F7FeatherBase device)
    {
        temperatureSensor = new SimulatedTemperatureSensor(
            22.Celsius(), 20.Celsius(), 24.Celsius());

        NetworkController = new NetworkController(device);
    }
}