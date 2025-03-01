using CharacterSheeet.Core.Contracts;
using Meadow;
using Meadow.Units;
using System.Threading.Tasks;

namespace CharacterSheeet.Core;

public class MainController
{
    private ICharacterSheeetHardware hardware;

    private CloudController cloudController;
    private ConfigurationController configurationController;
    private DisplayController displayController;
    private InputController inputController;
    private SensorController sensorController;

    private INetworkController NetworkController => hardware.NetworkController;

    private Temperature.UnitType units;
    private Temperature currentTemperature;
    private Temperature thresholdTemperature;

    public MainController()
    {
    }

    public Task Initialize(ICharacterSheeetHardware hardware)
    {
        this.hardware = hardware;

        this.thresholdTemperature = 68.Fahrenheit();

        // create generic services
        configurationController = new ConfigurationController();
        cloudController = new CloudController(Resolver.CommandService);
        sensorController = new SensorController(hardware);
        inputController = new InputController(hardware);

        units = configurationController.Units;
        thresholdTemperature = configurationController.ThresholdTemp;

        displayController = new DisplayController(
            this.hardware.Display,
            this.hardware.DisplayRotation,
            units);

        inputController.PreviousPageRequested += OnPreviousPageRequested;
        inputController.NextPageRequested += OnNextPageRequested;

        return Task.CompletedTask;
    }

    private void OnNextPageRequested(object sender, System.EventArgs e)
    {
        displayController.NextPage();
    }

    private void OnPreviousPageRequested(object sender, System.EventArgs e)
    {
        displayController.PreviousPage();
    }

    public async Task Run()
    {
        while (true)
        {
            // add any app logic here

            await Task.Delay(5000);
        }
    }
}