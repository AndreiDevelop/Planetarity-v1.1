using System;

public interface IAim
{
    void StartAim(Action afterStartAim);
    void StopAim(Action afterStopAim);
}
