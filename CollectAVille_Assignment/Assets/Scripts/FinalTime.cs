using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FinalTime : MonoBehaviour
{
    public TextMeshProUGUI PlayerTime;
    void Start()
    {
        TimeSpan time = TimeSpan.FromSeconds(Stopwatch.CurrentTime);
        PlayerTime.text = "Final Time: " + time.ToString(@"mm\:ss\:fff");
    }
}
