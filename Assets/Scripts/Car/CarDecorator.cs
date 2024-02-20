using System;
using UnityEngine;

namespace Car
{
    public class CarDecorator : MonoBehaviour
    {
        private CarDrive _carDrive;
        //
        public Transform headLight;
        public Transform tailLight;
        private bool _isHeadLightEnabled = false;
        private bool _isTailLightEnabled = false;

        private void Start()
        {
            _carDrive = GetComponent<CarDrive>();
        }

        private void LateUpdate()
        {
            _isTailLightEnabled = _carDrive.VerticalInput() < 0;
            headLight.gameObject.SetActive(_isHeadLightEnabled);
            tailLight.gameObject.SetActive(_isTailLightEnabled);
        }
    }
}