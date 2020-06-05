using UnityEngine;

[CreateAssetMenu(fileName = "AmmoConfigRandom ", menuName = "ScriptableObjects/AmmoConfigRandom ")]
public class AmmoConfigRandom : ScriptableObject
{
    [SerializeField] protected Vector2 _damageRange;
    public Vector2 DamageRange => _damageRange;
}
