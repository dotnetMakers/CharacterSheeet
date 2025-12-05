using CharacterSheeet.Core.Contracts;
using Meadow;
using System;

namespace CharacterSheeet.Core;

public enum NavigationState
{
    InterPage,
    IntraPage
}

public class InputController
{
    public event EventHandler? PreviousPageRequested;
    public event EventHandler? PreviousFieldRequested;
    public event EventHandler? NextPageRequested;
    public event EventHandler? NextFieldRequested;

    public event EventHandler? IncrementRequested;
    public event EventHandler? DecrementRequested;

    public event EventHandler? SelectRequested;

    public NavigationState NavigationState { get; private set; }

    public InputController(ICharacterSheeetHardware platform)
    {
        NavigationState = NavigationState.InterPage;

        if (platform.LeftButton is { } lb)
        {
            lb.PressStarted += (s, e) =>
            {
                Resolver.Log.Info($"LEFT");
                switch (NavigationState)
                {
                    case NavigationState.IntraPage:
                        break;
                    default:
                        PreviousPageRequested?.Invoke(this, EventArgs.Empty);
                        break;
                }
            };
        }
        if (platform.RightButton is { } rb)
        {
            Resolver.Log.Info($"RIGHT");
            rb.PressStarted += (s, e) => NextPageRequested?.Invoke(this, EventArgs.Empty);
        }
        if (platform.UpButton is { } ub)
        {
            Resolver.Log.Info($"UP");
            ub.PressStarted += (s, e) => IncrementRequested?.Invoke(this, EventArgs.Empty);
        }
        if (platform.DownButton is { } db)
        {
            Resolver.Log.Info($"DOWN");
            db.PressStarted += (s, e) => DecrementRequested?.Invoke(this, EventArgs.Empty);
        }
        if (platform.CenterButton is { } cb)
        {
            Resolver.Log.Info($"CENTER");
        }
    }
}
