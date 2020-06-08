using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAI : MonoBehaviour, IInput
{
    public event CustomEventHandler.EventHandler OnInputDown;
    public event CustomEventHandler.EventHandler OnInputUp;
}
