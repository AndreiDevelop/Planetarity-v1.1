using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour, IPlanetManager
{
    [SerializeField] private PlanetManagerConfig _planetManagerConfig;
    [SerializeField] private PlanetHolder _planetHolderPrefab;
    [SerializeField] private Planet _planet;

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        for(int i=0;i<_planetManagerConfig.OrbitRadiusArray.Length;i++)
        {
            PlanetHolder planetHolder = Instantiate(_planetHolderPrefab.gameObject, transform).GetComponent<PlanetHolder>();
            planetHolder.Initialize(_planet, _planetManagerConfig.OrbitRadiusArray[i]);
        }
    }
}
