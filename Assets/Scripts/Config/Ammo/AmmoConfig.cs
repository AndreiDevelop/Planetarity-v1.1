using UnityEngine;

[CreateAssetMenu(fileName = "AmmoConfig", menuName = "ScriptableObjects/AmmoConfig")]
public class AmmoConfig : ScriptableObject
{
    [SerializeField] private float _damage;
    public float Damage => _damage;
}
