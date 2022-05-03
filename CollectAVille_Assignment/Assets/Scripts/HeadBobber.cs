using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobber : MonoBehaviour
{
    public float WalkingBobbingSpeed = 14f;
    public float BobbingAmount = 0.1f;
    public Movement Controller;

    private float _defaultPosY = 0;
    private float _timer = 0;

    void Start()
    {
        _defaultPosY = transform.localPosition.y;
    }

    void Update()
    {
        if (Mathf.Abs(Controller.HorizontalVelocity.x) > 0.1f || Mathf.Abs(Controller.HorizontalVelocity.z) > 0.1f)
        {
            //Player is moving
            _timer += Time.deltaTime * WalkingBobbingSpeed;
            transform.localPosition = new Vector3(transform.localPosition.x, _defaultPosY + Mathf.Sin(_timer) * BobbingAmount, transform.localPosition.z);
        }
        else
        {
            //Idle
            _timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, _defaultPosY, Time.deltaTime * WalkingBobbingSpeed), transform.localPosition.z);
        }
    }
}
