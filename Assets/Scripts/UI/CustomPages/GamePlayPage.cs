using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayPage : PageUI
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Button _buttonExitToMenu;

    [System.Obsolete]
    public override void SetActivate(bool value, params object[] parameters)
    {
        if (value)
        {
            _buttonExitToMenu.onClick.AddListener(RestartGame);
        }
        else
        {
            _buttonExitToMenu.onClick.RemoveAllListeners();
        }
        base.SetActivate(value, parameters);
    }

    [System.Obsolete]
    private void RestartGame()
    {
        _gameManager.Restart();
    }
}
