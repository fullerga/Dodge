using System;

public interface PowerUp
{
    string Tag { get; }
    string TextForAnimation { get; }
    Action StartPowerup { get; }
}