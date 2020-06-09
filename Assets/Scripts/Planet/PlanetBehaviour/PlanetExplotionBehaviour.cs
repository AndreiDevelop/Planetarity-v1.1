using Lean.Pool;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetExplotionBehaviour : MonoBehaviour, ISimpleBehaviour
{
    [SerializeField] private ParticleSystem _explotionParticleSystemPrefab;
    private float _explotionLiveTime = 2f;

    public void Activate(Action onActivated, params object[] param)
    {
        GameObject explotion = LeanPool.Spawn(_explotionParticleSystemPrefab, transform.position, transform.rotation).gameObject;
        LeanPool.Despawn(explotion, _explotionLiveTime);
        onActivated?.Invoke();
    }

    public void Deacivate(Action onDeActivated, params object[] param)
    {
        onDeActivated?.Invoke();
    }
}
