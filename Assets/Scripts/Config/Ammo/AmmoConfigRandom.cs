using UnityEngine;

[CreateAssetMenu(fileName = "AmmoConfigRandom ", menuName = "ScriptableObjects/AmmoConfigRandom ")]
public class AmmoConfigRandom : AmmoConfig
{
    [SerializeField] protected Vector2 _damageRange;
    public new float Damage => Random.Range(_damageRange.x, _damageRange.y);
}
