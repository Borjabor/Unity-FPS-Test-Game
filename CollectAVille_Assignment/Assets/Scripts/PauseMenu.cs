using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : TimeManager
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject GameUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();                
            }
        }
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        GameUI.SetActive(false);
        FreezeTime();
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        GameUI.SetActive(true);
        ResumeTime();
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
