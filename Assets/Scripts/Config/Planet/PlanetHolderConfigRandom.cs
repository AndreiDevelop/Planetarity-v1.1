using UnityEngine;

[CreateAssetMenu(fileName = "PlanetHolderConfigRandom", menuName = "ScriptableObjects/PlanetHolderConfigRandom")]
public class PlanetHolderConfigRandom : PlanetHolderConfig
{
    [SerializeField] protected Vector2 _speedRotationRange;
    public override float SpeedRotation => RandomSpeed();

    private float RandomSpeed()
    {
        float speed = Random.Range(_speedRotationRange.x, _speedRotationRange.y);
        int speedModifier = (Random.value < 0.5f) ? -1 : 1;
        return speed * speedModifier;
    }

}
