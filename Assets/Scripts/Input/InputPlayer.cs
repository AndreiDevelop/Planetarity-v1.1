using UnityEngine;

public class InputPlayer : MonoBehaviour, IInput
{
    public event CustomEventHandler.EventHandler OnInputDown;
    public event CustomEventHandler.EventHandler OnInputUp;

    public void CallInputUp()
    {
        OnInputUp?.Invoke();
    }

    public void CallInputDown()
    {
        OnInputDown?.Invoke();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CallInputDown();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            CallInputUp();
        }
    }
}
