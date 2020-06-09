using UnityEngine;

public class RocketManager : AmmoManager
{
    [SerializeField] private Rocket _rocketPrefab;
    [SerializeField] private RocketConfig[] _rocketConfigArray;

    public override Ammo Ammo 
    { 
        get => _rocketPrefab; 
        set => _rocketPrefab = value as Rocket; 
    }

    void Awake()
    {
        InitializeAmmo();
    }

    public override void InitializeAmmo(params object[] param)
    {
        int index = Random.Range(0, _rocketConfigArray.Length - 1);
        _rocketPrefab.Initialize(_rocketConfigArray[index]);
    }
}
