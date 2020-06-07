using System;
using System.Linq;
using UnityEngine;

public class PlanetBehaviourManagerSimple : MonoBehaviour, ISimpleBehaviourManager
{
    private ISimpleBehaviour[] _behaviourArray;

    void Awake()
    {
        Initialize(GetComponentsInChildren<ISimpleBehaviour>());
    }

    public void Initialize(ISimpleBehaviour[] behaviourArray)
    {
        _behaviourArray = behaviourArray;
    }

    public ISimpleBehaviour SelectBehaviour(Type behaviourType)
    {
        return _behaviourArray.First(x => x.GetType() == behaviourType);
    }
}
