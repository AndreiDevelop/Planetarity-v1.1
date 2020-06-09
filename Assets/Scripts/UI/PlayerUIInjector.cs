using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIInjector : MonoBehaviour
{
    [SerializeField] private PlayerUIController _playerUIController;

    public void Initialize(Health healthPlanet)
    {
        _playerUIController.SetUp(healthPlanet.HealthValue);
        healthPlanet.OnHealtChanged += (value)=>_playerUIController.ChangeHealtSliderValue(value);
    }
}
