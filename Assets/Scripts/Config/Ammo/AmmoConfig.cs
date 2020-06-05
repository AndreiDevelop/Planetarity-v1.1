using UnityEngine;

[CreateAssetMenu(fileName = "AmmoConfig", menuName = "ScriptableObjects/AmmoConfig")]
public class AmmoConfig : ScriptableObject
{
    [SerializeField] protected float _damage;
    public float Damage => _damage;
}
