using System;
using System.Threading.Tasks;
using Meadow;
using Meadow.Foundation.Displays;
using Meadow.Pinouts;
using CharacterSheeet.Core;

namespace CharacterSheeet.RPi;

internal class MeadowApp : App<RaspberryPi>
{
    private CharacterSheeetHardware hardware;
    private MainController mainController;

    public bool SupportDisplay { get; set; } = false;

    public override Task Initialize()
    {
        hardware = new CharacterSheeetHardware(Device, SupportDisplay);
        mainController = new MainController();
        return mainController.Initialize(hardware);
    }

    public override Task Run()
    {
        if (hardware.Display is GtkDisplay gtk)
        {
            _ = mainController.Run();
            gtk.Run();
        }

        return mainController.Run();
    }
}