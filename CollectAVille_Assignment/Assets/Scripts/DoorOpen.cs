using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private GameObject _castleDoor;
    public TextMeshProUGUI GoalReachable;
    private int _targetPosY = 10;

    private void Awake()
    {
        GoalReachable.enabled = false;
    }
    void Update()
    {
        if (PointsManager.TotalPoints == 13)
        {
            EnableText();
            if (_castleDoor.transform.position.y < _targetPosY)
            {
                _castleDoor.transform.Translate(2f * Time.deltaTime, 0f, 0f);
            }
            StartCoroutine(FadeCoroutine());


        }
    }
    IEnumerator FadeCoroutine()
    {
        float _waitTime = 2;
        while (_waitTime > 0)
        {
            GoalReachable.fontMaterial.SetColor("_FaceColor", Color.Lerp(Color.clear, Color.white, _waitTime));
            yield return null;
            _waitTime -= Time.deltaTime;
            if (_waitTime <= 0.2)
            {
                GoalReachable.enabled = false;
            }
        }

        

    }

    public void EnableText()
    {
        GoalReachable.enabled = true;
    }

}
