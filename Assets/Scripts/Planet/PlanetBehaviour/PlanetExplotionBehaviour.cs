using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetExplotionBehaviour : MonoBehaviour, ISimpleBehaviour
{
    public void Activate(Action onActivated, params object[] param)
    {
        onActivated?.Invoke();
    }

    public void Deacivate(Action onDeActivated, params object[] param)
    {
        onDeActivated?.Invoke();
    }
}
