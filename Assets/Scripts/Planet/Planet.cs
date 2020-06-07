﻿using UnityEngine;

public class Planet : MonoBehaviour, IPlanet
{
    [SerializeField] private float _speedRotate = 0;
    [SerializeField] private bool _isInitialized = false;
    [SerializeField] private Health _health;

    private ISimpleBehaviourManager _behaviourManager;

    void Awake()
    {
        Initialize();
    }

    void OnEnable()
    {
        _health.OnHealtChanged += OnHealthChange;
    }

    void OnDisable()
    {
        _health.OnHealtChanged -= OnHealthChange;
    }

    public void Initialize()
    {
        _behaviourManager = GetComponent<ISimpleBehaviourManager>();

        float randomRotateAngle = Random.Range(-360f, 360f);

        transform.localEulerAngles = new Vector3(0f, 0f, randomRotateAngle);

        _isInitialized = true;
    }

    private void OnHealthChange(float healtValue)
    {
        if(healtValue == 0)
        {
            _behaviourManager.SelectBehaviour(typeof(PlanetExplotionBehaviour)).Activate(()=>gameObject.SetActive(false));
        }
    }

    private void Update()
    {
        if (_isInitialized)
        {
            transform.Rotate(0, 0, Time.deltaTime * _speedRotate);
        }
    }

}
