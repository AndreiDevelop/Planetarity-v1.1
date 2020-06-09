
using System;

public interface ISimpleBehaviour
{
    void Activate(Action onActivated, params object[] param);
    void Deacivate(Action onDeActivated, params object[] param);
}
