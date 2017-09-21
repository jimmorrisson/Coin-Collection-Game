using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    private float _sensitivity = 10.0f;
    private PlayerMotor _motor;
    private bool _isRunning;

    private void Start()
    {
        _motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float yRot = Input.GetAxis("Mouse X");
        float xRot = -Input.GetAxis("Mouse Y");
        _isRunning = false;

        Vector3 movHorizontal = transform.right * x;
        Vector3 movVertical = transform.forward * z;
        Vector3 rotation = new Vector3(0, yRot, 0) * _sensitivity;
        //Debug.Log(rotation);
        Vector3 cameraRotation = new Vector3(xRot, 0, 0) * _sensitivity;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _isRunning = true;
        }

        if (_isRunning)
        {
            _speed = 8.0f;
        }

        else
        {
            _speed = 5.0f;
        }

        Vector3 velocity = (movHorizontal + movVertical).normalized * _speed;
        //Debug.Log(velocity);

        _motor.Move(velocity, _isRunning);
        _motor.Rotate(rotation);
        _motor.RotateCamera(cameraRotation);
    }
}
