
public interface IInput
{
    event CustomEventHandler.EventHandler OnInputDown;
    event CustomEventHandler.EventHandler OnInputUp;

    void CallInputDown();
    void CallInputUp();
}
