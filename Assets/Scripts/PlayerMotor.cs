using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private Vector3 _velocity = Vector3.zero;
    private Vector3 _rotation = Vector3.zero;
    private Vector3 _cameraRotation = Vector3.zero;
    private Rigidbody _rb;
    private Camera _camera;
    private float _walkHeadbobbing = 6f;
    private float _runHeadbobbing = 8f;
    private float _headbobbingRange = -0.03f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
        PerformCameraRotation();
    }

    public void Move(Vector3 velocity, bool isRunning)
    {
        _velocity = velocity;
        if (_velocity != Vector3.zero)
        {
            BobTheHead(isRunning);
        }
    }

    public void Rotate(Vector3 rotation)
    {
        _rotation = rotation;
    }

    public void RotateCamera(Vector3 cameraRotation)
    {
        _cameraRotation = cameraRotation;
    }

    private void BobTheHead(bool isRunning)
    {
        float yPos;
        if (!isRunning)
        {
            yPos = Mathf.Cos(Time.time * _walkHeadbobbing) * _headbobbingRange;
        }
        else
        {
            yPos = Mathf.Cos(Time.time * _runHeadbobbing) * _headbobbingRange;
        }
        _camera.transform.position += new Vector3(0, yPos, 0);
    }

    private void PerformMovement()
    {
        if (_velocity != Vector3.zero)
        {
            _rb.MovePosition(transform.position + _velocity * Time.fixedDeltaTime);
        }
    }

    private void PerformRotation()
    {
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(_rotation));
    }

    private void PerformCameraRotation()
    {
        _camera.transform.Rotate(_cameraRotation);
    }
}
