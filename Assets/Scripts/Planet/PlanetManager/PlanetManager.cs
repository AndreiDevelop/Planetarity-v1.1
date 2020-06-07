using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour, IPlanetManager
{
    [SerializeField] private PlanetManagerConfig _planetManagerConfig;
    [SerializeField] private PlanetHolder _planetHolderPrefab;
    [SerializeField] private Planet _planetAI;
    [SerializeField] private Planet _planetPlayer;

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _planetManagerConfig.OrbitRadiusArray.Shuffle();

        for (int i=0;i<_planetManagerConfig.OrbitRadiusArray.Length;i++)
        {
            PlanetHolder planetHolder = Instantiate(_planetHolderPrefab.gameObject, transform).GetComponent<PlanetHolder>();
            
            if (i == 0)
            {
                planetHolder.Initialize(_planetPlayer, _planetManagerConfig.OrbitRadiusArray[i]);
            }
            else
            {
                planetHolder.Initialize(_planetAI, _planetManagerConfig.OrbitRadiusArray[i]);
            }
            
            
        }
    }
}
