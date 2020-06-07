using UnityEngine;

public class Planet : MonoBehaviour, IPlanet
{
    [SerializeField] private float _speedRotate = 0;
    [SerializeField] private bool _isInitialized = false;

  

    void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {

        float randomRotateAngle = Random.Range(-360f, 360f);

        transform.localEulerAngles = new Vector3(0f, 0f, randomRotateAngle);

        _isInitialized = true;
    }

    private void Update()
    {
        if (_isInitialized)
        {
            transform.Rotate(0, 0, Time.deltaTime * _speedRotate);
        }
    }

}
