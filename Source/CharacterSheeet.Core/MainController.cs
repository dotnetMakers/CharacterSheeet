using CharacterSheeet.Core.Contracts;
using CharacterSheeet.Dcc;
using Meadow;
using System.Threading.Tasks;

namespace CharacterSheeet.Core;

public class MainController
{
    private ICharacterSheeetHardware hardware;
    private Character _character;

    private CloudController cloudController;
    private ConfigurationController configurationController;
    private DisplayController displayController;
    private InputController inputController;
    private SensorController sensorController;

    private INetworkController NetworkController => hardware.NetworkController;

    public MainController()
    {
    }


    public Task Initialize(ICharacterSheeetHardware hardware)
    {
        this.hardware = hardware;

        _character = CharacterGenerator.GenerateHalfling();

        // create generic services
        configurationController = new ConfigurationController();
        cloudController = new CloudController(Resolver.CommandService);
        sensorController = new SensorController(hardware);
        inputController = new InputController(hardware);

        displayController = new DisplayController(
            this.hardware.Display,
            this.hardware.DisplayRotation,
            _character);

        // Left/Right buttons: Navigate through selections
        inputController.PreviousPageRequested += OnLeftButton;
        inputController.NextPageRequested += OnRightButton;

        // Up/Down buttons: Modify selected value
        inputController.IncrementRequested += OnUpButton;
        inputController.DecrementRequested += OnDownButton;

        return Task.CompletedTask;
    }

    private void OnLeftButton(object sender, System.EventArgs e)
    {
        Resolver.Log.Info("Left button pressed - select previous");
        displayController.SelectPrevious();
    }

    private void OnRightButton(object sender, System.EventArgs e)
    {
        Resolver.Log.Info("Right button pressed - select next");
        displayController.SelectNext();
    }

    private void OnUpButton(object sender, System.EventArgs e)
    {
        Resolver.Log.Info("Up button pressed - increment value");
        displayController.IncrementSelectedValue();
    }

    private void OnDownButton(object sender, System.EventArgs e)
    {
        Resolver.Log.Info("Down button pressed - decrement value");
        displayController.DecrementSelectedValue();
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