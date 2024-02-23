using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CarShowcase : MonoBehaviour
{
    public Car.Car carOrigion;
    
    private Vector3 _currentRotation;
    
    private float _rotationDelta;
    private float _defaultRotationValue;
    

    private void Start()
    {
        _currentRotation.y = transform.rotation.y;
        _defaultRotationValue = _currentRotation.y;
        _rotationDelta = GameObject.Find("CarSelectionManager").GetComponent<CarSelectionManager>().carRotationSpeed;
    }

    private void FixedUpdate()
    {
        RotateDisplayCar();
    }

    private void OnEnable()
    {
        _currentRotation.y = _defaultRotationValue;
    }

    private void RotateDisplayCar()
    {
        if (!gameObject.activeInHierarchy) return;
        _currentRotation.y += _rotationDelta;
        transform.localEulerAngles = _currentRotation;
    }
}
