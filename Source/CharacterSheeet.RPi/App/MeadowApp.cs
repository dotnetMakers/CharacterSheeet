using CharacterSheeet.Core;
using Meadow;
using System.Threading.Tasks;

namespace CharacterSheeet.RPi;

internal class MeadowApp : App<RaspberryPi>
{
    private CharacterSheeetHardware hardware;
    private MainController mainController;

    public override Task Initialize()
    {
        hardware = new CharacterSheeetHardware(Device);
        mainController = new MainController();
        return mainController.Initialize(hardware);
    }

    public override Task Run()
    {
        return mainController.Run();
    }
}