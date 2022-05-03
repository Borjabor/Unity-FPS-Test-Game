using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float _sensitivityX = 100f;
    [SerializeField] private float _sensitivityY = 80f;
    private float _mouseX, _mouseY;

    [SerializeField] private Transform _playerCamera;
    private float _xClamp = 85f;
    private float _xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            _mouseX = Input.GetAxis("Mouse X") * _sensitivityX * Time.deltaTime;
            _mouseY = Input.GetAxis("Mouse Y") * _sensitivityY * Time.deltaTime;

            _xRotation -= _mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -_xClamp, _xClamp);

            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            _playerCamera.Rotate(Vector3.up * _mouseX);
        }
        
    }

}
