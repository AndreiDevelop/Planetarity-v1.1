using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    [SerializeField] private GameObject _ammoPrefab;
    [SerializeField] private float _shootPower = 100f;

    public void Fire(params object[] param)
    {
        Rigidbody2D ammoRigidbody = Instantiate(_ammoPrefab, transform.position, transform.rotation).GetComponent<Rigidbody2D>();
        ammoRigidbody.AddForce(transform.up * _shootPower);  
    }
}
