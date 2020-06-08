using UnityEngine;

[CreateAssetMenu(fileName = "RocketConfig", menuName = "ScriptableObjects/RocketConfig")]
public class RocketConfig : AmmoConfig
{
    [SerializeField] private float _acceleration;
    public float Acceleration => _acceleration;

    [SerializeField] private float _mass;
    public float Mass => _mass;

    [SerializeField] private float _coolDown;
    public float CoolDown => _coolDown;
}
