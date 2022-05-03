using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Stopwatch : MonoBehaviour
{
    private bool _isActive = false;
    public static float CurrentTime;
    public TextMeshProUGUI GameTime;

    void Start()
    {
        CurrentTime = 0;
        StartStopwatch();
    }

    
    void Update()
    {
        if (_isActive == true)
        {
            CurrentTime += Time.deltaTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
        GameTime.text = "Time: " + time.ToString(@"mm\:ss\:ff");
    }

    public void StartStopwatch()
    {
        _isActive = true;
    }

    public void StopStopwatch()
    {
        _isActive = false;
    }
}
