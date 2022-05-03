using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : Collectible
{
    private Stopwatch _stopwatch;

    private void Start()
    {
        _stopwatch = new Stopwatch();
    }
    public override void Collect()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _stopwatch.StopStopwatch();
        GameOver();
    }
    
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
