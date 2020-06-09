public interface IPageUIController
{
    IEnviromentController EnviromentController { get; }
    void SwitchPageOn<T>(params object[] parameters) where T : PageUI;
    void SwitchPageBack();
}
