using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _gameIsPaused = false;

    [System.Obsolete]
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SetPauseUnpauseGame();
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    private void SetPauseUnpauseGame()
    {
        _gameIsPaused = !_gameIsPaused;
        Time.timeScale = (_gameIsPaused) ? 0 : 1;
    }

    [System.Obsolete]
    private void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
