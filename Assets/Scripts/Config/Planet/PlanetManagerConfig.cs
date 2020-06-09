using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetManagerConfig", menuName = "ScriptableObjects/PlanetManagerConfig")]
public class PlanetManagerConfig : ScriptableObject
{
    [SerializeField] private float[] _orbitRadiusArray;
    public float[] OrbitRadiusArray => _orbitRadiusArray;

    [SerializeField] private Vector2 _minMaxPlanetsCountRange;
    public float RandomPlanetCount => CalculateRandomPlanetCount();
    private float CalculateRandomPlanetCount()
    {
        float minCount = Mathf.Clamp(_minMaxPlanetsCountRange.x, 2, _orbitRadiusArray.Length);
        float maxCount = Mathf.Clamp(_minMaxPlanetsCountRange.y, minCount, _orbitRadiusArray.Length);

        return Random.Range(minCount, maxCount);
    }
}
