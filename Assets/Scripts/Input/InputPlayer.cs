using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour, IInput
{
    public event CustomEventHandler.EventHandler DoInput;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DoInput?.Invoke();
        }
    }
}
