using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float _defaultPosY = 0;
    private float _timer = 0;

    void Start()
    {
        _defaultPosY = transform.localPosition.y;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        _timer += Time.deltaTime * 2;
        transform.localPosition = new Vector3(transform.localPosition.x, _defaultPosY + Mathf.Sin(_timer) * 0.1f, transform.localPosition.z);
    }
}
