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

        // Wire up button events
        inputController.PreviousPageRequested += OnLeftButton;
        inputController.NextPageRequested += OnRightButton;
        inputController.IncrementRequested += OnUpButton;
        inputController.DecrementRequested += OnDownButton;
        inputController.SelectRequested += OnCenterButton;

        return Task.CompletedTask;
    }

    private void OnCenterButton(object sender, System.EventArgs e)
    {
        Resolver.Log.Info("Center button - toggle activation");
        displayController.ToggleActivation();
    }

    private void OnLeftButton(object sender, System.EventArgs e)
    {
        if (displayController.IsActivated)
        {
            // Activated: decrement value
            Resolver.Log.Info("Left button (activated) - decrement value");
            displayController.DecrementSelectedValue();
        }
        else
        {
            // Not activated: previous page
            Resolver.Log.Info("Left button - previous page");
            displayController.PreviousPage();
        }
    }

    private void OnRightButton(object sender, System.EventArgs e)
    {
        if (displayController.IsActivated)
        {
            // Activated: increment value
            Resolver.Log.Info("Right button (activated) - increment value");
            displayController.IncrementSelectedValue();
        }
        else
        {
            // Not activated: next page
            Resolver.Log.Info("Right button - next page");
            displayController.NextPage();
        }
    }

    private void OnUpButton(object sender, System.EventArgs e)
    {
        if (displayController.IsActivated)
        {
            // Activated: increment value
            Resolver.Log.Info("Up button (activated) - increment value");
            displayController.IncrementSelectedValue();
        }
        else
        {
            // Not activated: select previous
            Resolver.Log.Info("Up button - select previous");
            displayController.SelectPrevious();
        }
    }

    private void OnDownButton(object sender, System.EventArgs e)
    {
        if (displayController.IsActivated)
        {
            // Activated: decrement value
            Resolver.Log.Info("Down button (activated) - decrement value");
            displayController.DecrementSelectedValue();
        }
        else
        {
            // Not activated: select next
            Resolver.Log.Info("Down button - select next");
            displayController.SelectNext();
        }
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