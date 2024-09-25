using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public enum Axel
    {
        Front,
        Rear
    }
    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public Axel axel;

    }
    public float _maxAcceleration = 30.0f;
    public float _brakeAcceleration = 50.0f;

    public float _turnSensitivity = 1.0f;
    public float _maxSteerAngle = 50.0f;

    public Vector3 _centerOfMass;

    public List<Wheel> wheels;

    float _moveInput;
    float _steerInput;
    private Rigidbody _carRb;

    private void Start()
    {
        _carRb = GetComponent<Rigidbody>();
        _carRb.centerOfMass = _centerOfMass;

        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                wheel.wheelCollider.suspensionDistance = 0.2f;
            }
            else
            {
                wheel.wheelCollider.suspensionDistance = 0.2f;
            }
        }
    }

    private void Update()
    {
       

        GetInputs();
        AnimateWheels();
    }
    private void LateUpdate()
    {
        Move();
        Steer();
        Brake();
    }
    void GetInputs()
    {
        _moveInput = Input.GetAxis("Vertical");
        _steerInput = Input.GetAxis("Horizontal");
    }
    void Move()
    {
        foreach(var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = _moveInput * 300 * _maxAcceleration * Time.deltaTime;
        }
    }

    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front) {
                var steerAngle = _steerInput * _turnSensitivity * _maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, steerAngle, 0.6f); 
            }
        }
    }

    void Brake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (var wheel in wheels)
            { 
                wheel.wheelCollider.brakeTorque = 300 * _brakeAcceleration * Time.deltaTime;
            }
        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }
        }
    }

    void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion wheelRotation;
            Vector3 position;

            wheel.wheelCollider.GetWorldPose(out position, out wheelRotation);
            wheel.wheelModel.transform.position = position;
            wheel.wheelModel.transform.rotation = wheelRotation;
        }
    }

}
