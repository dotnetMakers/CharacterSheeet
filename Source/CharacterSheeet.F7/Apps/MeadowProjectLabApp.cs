using System;
using System.Threading.Tasks;
using Meadow;
using Meadow.Devices;
using CharacterSheeet.Core;

namespace CharacterSheeet.F7;

public class MeadowProjectLabApp : App<F7CoreComputeV2>
{
    private MainController mainController;

    public override Task Initialize()
    {
        var hardware = new CharacterSheeetProjectLabHardware(Device);
        mainController = new MainController();
        return mainController.Initialize(hardware);
    }

    public override Task Run()
    {
        return mainController.Run();
    }
}