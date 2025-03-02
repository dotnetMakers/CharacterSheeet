using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CharacterSheeet.Dcc;

public static class Extensions
{
    public static string ToRomanNumeral(this int i)
    {
        return i switch
        {
            1 => "I",
            2 => "II",
            3 => "III",
            4 => "IV",
            5 => "V",
            6 => "VI",
            7 => "VII",
            8 => "VIII",
            9 => "IX",
            10 => "X",
            _ => i.ToString()
        };
    }

    public static bool SetAndRaiseIfChanged<T, TProperty>(
        this T instance,
        ref TProperty field,
        TProperty value,
        Action<PropertyChangedEventArgs> raiseEvent,
        [CallerMemberName] string? propertyName = null)
        where T : INotifyPropertyChanged
    {
        if (EqualityComparer<TProperty>.Default.Equals(field, value))
        {
            return false;
        }

        field = value;

        raiseEvent(new PropertyChangedEventArgs(propertyName));
        return true;
    }
}

