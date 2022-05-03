using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Horizontal Movement Variables
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed = 11f;
    [SerializeField] private AudioSource _footsteps;
    public Vector3 HorizontalVelocity = Vector3.zero;

    //Vertical Movement Variables
    [SerializeField] private float _jumpHeight = 3.5f;
    [SerializeField] private float _gravity = -30f; //feels better than real life gravity
    [SerializeField] private LayerMask _groundMask;
    private Vector3 _verticalVelocity = Vector3.zero;
    private bool _isGrounded;

    private void Update()
    {
        _isGrounded = Physics.CheckSphere(transform.position, 0.1f, _groundMask);
        if (_isGrounded)
        {
            _verticalVelocity.y = 0;
        }

        float _x = Input.GetAxis("Horizontal");
        float _z = Input.GetAxis("Vertical");

        HorizontalVelocity = (transform.right * _x + transform.forward * _z) * _speed;
        _controller.Move(HorizontalVelocity * Time.deltaTime);

        if (HorizontalVelocity != Vector3.zero && Time.timeScale != 0f && _isGrounded)
        {
            if (!_footsteps.isPlaying)
            {
                _footsteps.Play();
            }

        }
        else
        {
            _footsteps.Stop();
        }

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _verticalVelocity.y = Mathf.Sqrt(-2f * _jumpHeight * _gravity);
            
        }

        _verticalVelocity.y += _gravity * Time.deltaTime;
        _controller.Move(_verticalVelocity * Time.deltaTime);
    }

}
