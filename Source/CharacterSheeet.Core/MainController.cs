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

        inputController.PreviousPageRequested += OnPreviousPageRequested;
        inputController.NextPageRequested += OnNextPageRequested;
        inputController.IncrementRequested += OnIncrementRequested;
        inputController.DecrementRequested += OnDecrementRequested;

        return Task.CompletedTask;
    }

    private void OnDecrementRequested(object sender, System.EventArgs e)
    {
        _character.CurrentHitPoints--;
    }

    private void OnIncrementRequested(object sender, System.EventArgs e)
    {
        _character.CurrentHitPoints++;
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