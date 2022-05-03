using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public static int TotalPoints = 0;
    public TextMeshProUGUI TargetCount;
    public TextMeshProUGUI StartMessage;

    private void Start()
    {
        SetCountText();
        StartCoroutine(FadeCoroutine());
    }

    void FixedUpdate()
    {
        SetCountText();
    }

    void SetCountText()
    {
        TargetCount.text = "TARGETS DESTROYED : " + TotalPoints.ToString() + " / 13";
    }

    IEnumerator FadeCoroutine()
    {
        float _waitTime = 3;
        while (_waitTime > 0)
        {
            StartMessage.fontMaterial.SetColor("_FaceColor", Color.Lerp(Color.clear, Color.white, _waitTime));
            yield return null;
            _waitTime -= Time.deltaTime;
        }

        if (_waitTime <=0)
        {
            StartMessage.enabled = false;
        }

    }
}
