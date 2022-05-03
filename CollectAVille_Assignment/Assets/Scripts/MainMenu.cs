using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : TimeManager
{
    public void PlayGame()
    {
        SceneManager.LoadScene("TownLevel");
        PointsManager.TotalPoints = 0;
        PauseMenu.GameIsPaused = false;
        ResumeTime();
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game"); //Left in as a placeholder for the actual window close that would happen in the game
        Application.Quit();
    }
}
