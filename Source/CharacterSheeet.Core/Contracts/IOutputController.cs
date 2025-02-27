using System;
using System.Threading.Tasks;

namespace CharacterSheeet.Core;

public interface IOutputController
{
    Task SetState(bool state);
}