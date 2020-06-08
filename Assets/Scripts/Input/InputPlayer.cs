using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour, IInput
{
    public event CustomEventHandler.EventHandler OnInputDown;
    public event CustomEventHandler.EventHandler OnInputUp;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnInputDown?.Invoke();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            OnInputUp?.Invoke();
        }
    }
}
