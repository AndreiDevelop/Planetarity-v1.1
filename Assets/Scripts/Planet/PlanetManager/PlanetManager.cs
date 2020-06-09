using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour, IPlanetManager
{
    [SerializeField] private PlanetManagerConfig _planetManagerConfig;
    [SerializeField] private PlanetHolder _planetHolderPrefab;
    [SerializeField] private Planet _planetAI;
    [SerializeField] private Planet _planetPlayer;

    private PlayerUIInjector _playerUIInjector;

    void Awake()
    {
        _playerUIInjector = GetComponent<PlayerUIInjector>();
    }

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _planetManagerConfig.OrbitRadiusArray.Shuffle();

        for (int i=0;i<_planetManagerConfig.RandomPlanetCount; i++)
        {
            PlanetHolder planetHolder = Instantiate(_planetHolderPrefab.gameObject, transform).GetComponent<PlanetHolder>();
            
            if (i == 0)
            {
                planetHolder.Initialize(_planetPlayer, _planetManagerConfig.OrbitRadiusArray[i],(planet)=>
                {
                    _playerUIInjector.Initialize(planet.Health);
                });
            }
            else
            {
                planetHolder.Initialize(_planetAI, _planetManagerConfig.OrbitRadiusArray[i]);
            }
            
            
        }
    }
}
