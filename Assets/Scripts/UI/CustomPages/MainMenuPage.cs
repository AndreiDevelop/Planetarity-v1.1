using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPage : PageUI
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Button _buttonStartGame;
    [SerializeField] private Button _buttonExitGame;

    [System.Obsolete]
    public override void SetActivate(bool value, params object[] parameters)
    {
        if(value)
        {
            PageController.EnviromentController.SwitchEnviromentOn<EnviromentEmpty>();
            _buttonStartGame.onClick.AddListener(StartGame);
            _buttonExitGame.onClick.AddListener(() => _gameManager.Exit());
        }
        else
        {
            _buttonStartGame.onClick.RemoveAllListeners();
        }
        base.SetActivate(value, parameters);
    }

    private void StartGame()
    {
        PageController.EnviromentController.SwitchEnviromentOn<EnviromentSolarSystem>();
        PageController.SwitchPageOn<GamePlayPage>();
    }
}
