using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetManagerConfig", menuName = "ScriptableObjects/PlanetManagerConfig")]
public class PlanetManagerConfig : ScriptableObject
{
    [SerializeField] private float[] _orbitRadiusArray;
    public float[] OrbitRadiusArray => _orbitRadiusArray;

}
