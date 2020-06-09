using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHitable
{
    public delegate void HealthHandler(float value);
    public event HealthHandler OnHealtChanged;

    [SerializeField] private float _healthValue;
    public float HealthValue => _healthValue;

    public virtual void TakeHit(float damageValue)
    {
        float newHealthValue = _healthValue - damageValue;
        _healthValue = Mathf.Clamp(newHealthValue, 0f, float.MaxValue);

        OnHealtChanged?.Invoke(_healthValue);
    }
}
