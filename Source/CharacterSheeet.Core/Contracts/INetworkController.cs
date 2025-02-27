using System;
using System.Threading.Tasks;

namespace CharacterSheeet.Core;

public interface INetworkController
{
    event EventHandler NetworkStatusChanged;

    Task Connect();
    bool IsConnected { get; }
}