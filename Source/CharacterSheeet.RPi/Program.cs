using System;
using System.Threading.Tasks;
using Meadow;
using Meadow.Foundation.Displays;
using Meadow.Logging;
using CharacterSheeet.Core;

namespace CharacterSheeet.RPi;

public static class Program
{
    private static void Main(string[] args)
    {
        MeadowOS.Start(args);
    }
}