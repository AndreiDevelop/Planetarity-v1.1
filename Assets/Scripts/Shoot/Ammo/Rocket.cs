using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Ammo
{
    public LayerMask destroyLayerMask;

    [SerializeField] private ParticleSystem _explotionParticleSystemPrefab;
    [SerializeField] private RocketConfig _config;
    public RocketConfig Config
    {
        get
        {
            return _config;
        }
        set
        {
            _config = value;
        }
    }

    private Rigidbody2D _rigidbody2D;
    private float _selfDestroyTimeInSeconds = 10f;

    void Awake()
    {
        if(_config!=null)
        {
            Initialize(_config);
        }
    }

    public void Initialize(RocketConfig config)
    {
        Config = config;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.mass = Config.Mass;
    }

    public void RocketLaunch(Vector3 direction)
    {
        _rigidbody2D.AddForce(direction * Config.Acceleration);
        StartCoroutine(SelfDestroy());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & destroyLayerMask) != 0)
        {
            DestroyRocket();
        }
    }

    void Update()
    {
        transform.up = _rigidbody2D.velocity;
    }

    private IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(_selfDestroyTimeInSeconds);
        DestroyRocket();
    }

    private void DestroyRocket()
    {
        Instantiate(_explotionParticleSystemPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
