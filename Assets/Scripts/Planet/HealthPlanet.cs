using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlanet : Health
{
    [SerializeField] private Slider _healtSlider;

    private void Awake()
    {
        _healtSlider.maxValue = HealthValue;
        _healtSlider.value = HealthValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rocket rocket;
        if(rocket = collision.GetComponent<Rocket>())
        {
            _healtSlider.value -= rocket.Config.Damage;
            TakeHit(rocket.Config.Damage);
        }
    }
}
