﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetHolder : MonoBehaviour
{
    [SerializeField] private PlanetHolderConfig _planetHolderConfig;
    [SerializeField] private float _speedRotate = 0;
    [SerializeField] private bool _isInitialized = false;
    public void Initialize(Planet planet, float radius)
    {
        Transform planetTransform = Instantiate(planet.gameObject, transform).transform;
        planetTransform.localPosition = new Vector3(radius, 0, 0);

        _speedRotate = _planetHolderConfig.SpeedRotation;

        float randomRotateAngle = Random.Range(-360f, 360f);

        transform.localEulerAngles = new Vector3(0f, randomRotateAngle, 0f);

        _isInitialized = true;
    }

    private void Update()
    {
        if(_isInitialized)
        {
            transform.Rotate(0, Time.deltaTime * _speedRotate, 0);
        }        
    }
}
