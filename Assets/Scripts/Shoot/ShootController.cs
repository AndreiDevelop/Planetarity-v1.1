using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private GameObject _aimObject;
    [SerializeField] private GameObject _gunObject;
    [SerializeField] private AmmoManager _ammoManager;
    public AmmoManager AmmoManager => _ammoManager;

    private IAim _aim;
    private IGun _gun;
    private IInput _input;

    private void Awake()
    {
        _aim = _aimObject.GetComponent<IAim>();
        _gun = _gunObject.GetComponent<IGun>();
        _input = GetComponent<IInput>();
    }

    private void OnEnable()
    {
        _input.OnInputDown += StartAim;
        _input.OnInputUp += StopAimAndShoot;
    }

    private void OnDisable()
    {
        _input.OnInputDown -= StartAim;
        _input.OnInputUp -= StopAimAndShoot;
    }

    private void StartAim()
    {
        _aim.StartAim(null);
    }

    private void StopAimAndShoot()
    {
        _aim.StopAim(Shoot);
    }

    private void Shoot()
    {
        _gun.Fire(_ammoManager.Ammo.gameObject);
    }
}
