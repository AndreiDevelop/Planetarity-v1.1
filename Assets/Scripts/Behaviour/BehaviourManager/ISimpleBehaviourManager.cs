
using System;

public interface ISimpleBehaviourManager
{
    void Initialize(ISimpleBehaviour[] behaviourArray);
    ISimpleBehaviour SelectBehaviour(Type behaviourType);
}
