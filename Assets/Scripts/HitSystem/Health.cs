using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHitable
{
    public delegate void HealthHandler(float value);
    public event HealthHandler OnHealtChanged;

    [SerializeField] protected float _healthValue;

    public virtual void TakeHit(float damageValue)
    {
        float newHealthValue = _healthValue - damageValue;
        _healthValue = Mathf.Clamp(_healthValue, 0f, float.MaxValue);

        OnHealtChanged?.Invoke(_healthValue);
    }
}
