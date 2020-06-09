using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentSolarSystem : Enviroment
{
    [SerializeField] private GameManager _gameManager;
    public override void SetActivate(bool value, params object[] parameters)
    {
        base.SetActivate(value, parameters);
    }
}
