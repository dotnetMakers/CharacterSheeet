using CharacterSheeet.Core;
using CharacterSheeet.Core.Contracts;
using Meadow.Devices;
using Meadow.Peripherals.Displays;
using Meadow.Peripherals.Sensors.Buttons;

namespace CharacterSheeet.F7;

internal class CharacterSheeetProjectLabHardware : ICharacterSheeetHardware
{
    private readonly IProjectLabHardware projLab;

    public RotationType DisplayRotation => RotationType._270Degrees;
    public IButton? LeftButton => projLab.LeftButton;
    public IButton? RightButton => projLab.RightButton;
    public IButton? UpButton => projLab.LeftButton;
    public IButton? DownButton => projLab.RightButton;
    public IPixelDisplay? Display => projLab.Display;
    public INetworkController NetworkController { get; }

    public CharacterSheeetProjectLabHardware(F7CoreComputeV2 device)
    {
        projLab = ProjectLab.Create();

        NetworkController = new NetworkController(device);
    }
}