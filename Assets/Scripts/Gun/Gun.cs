using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _ammoPrefab;
    [SerializeField] private float _forceMultiplayer = 100f;
    private IInput _input;

    private void Awake()
    {
        _input = GetComponent<IInput>();
    }

    private void OnEnable()
    {
        _input.DoInput += FireByInput;
    }

    private void OnDisable()
    {
        _input.DoInput -= FireByInput;
    }

    private void FireByInput(params object[] param)
    {
        Rigidbody2D ammoRigidbody = Instantiate(_ammoPrefab, transform.position, transform.rotation).GetComponent<Rigidbody2D>();
        ammoRigidbody.AddForce(transform.up * _forceMultiplayer);
    }
}
