﻿using System;
using System.Threading.Tasks;
using Meadow;
using Meadow.Devices;
using Meadow.Foundation.Leds;
using Meadow.Foundation.Sensors;
using Meadow.Peripherals.Displays;
using Meadow.Peripherals.Sensors;
using Meadow.Peripherals.Sensors.Buttons;
using Meadow.Units;
using CharacterSheeet.Core;
using CharacterSheeet.Core.Contracts;

namespace CharacterSheeet.F7;

internal class CharacterSheeetF7FeatherHardware : ICharacterSheeetHardware
{
    private readonly ITemperatureSensor temperatureSensor;

    public RotationType DisplayRotation => RotationType.Default;
    public ITemperatureSensor? TemperatureSensor => temperatureSensor;
    public IOutputController OutputController { get; }
    public IButton? RightButton => null;
    public IButton? LeftButton => null;
    public IPixelDisplay? Display => null;
    public INetworkController NetworkController { get; }

    public CharacterSheeetF7FeatherHardware(F7FeatherBase device)
    {
        temperatureSensor = new SimulatedTemperatureSensor(
            22.Celsius(), 20.Celsius(), 24.Celsius());

        OutputController = new OutputController(
            new RgbLed(
                device.Pins.OnboardLedRed.CreateDigitalOutputPort(),
                device.Pins.OnboardLedGreen.CreateDigitalOutputPort(),
                device.Pins.OnboardLedBlue.CreateDigitalOutputPort()
                )
            );

        NetworkController = new NetworkController(device);
    }
}