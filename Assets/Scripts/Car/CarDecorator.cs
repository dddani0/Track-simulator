using System;
using UnityEngine;

namespace Car
{
    public class CarDecorator : MonoBehaviour
    {
        private IngameManager _ingameManager;

        //
        private CarDrive _carDrive;

        //
        public Transform headLight;
        public Transform tailLight;
        private bool _isHeadLightEnabled = false;
        private bool _isTailLightEnabled = false;

        private void Start()
        {
            _ingameManager = GameObject.FindGameObjectWithTag("IngameManager").GetComponent<IngameManager>();
            _carDrive = GetComponent<CarDrive>();
        }

        private void Update()
        {
            SwitchHeadlight();
        }

        private void LateUpdate()
        {
            _isTailLightEnabled = _carDrive.VerticalInput() < 0;
            headLight.gameObject.SetActive(_isHeadLightEnabled);
            tailLight.gameObject.SetActive(_isTailLightEnabled);
        }

        private void SwitchHeadlight()
        {
            if (!Input.GetKeyDown(_ingameManager.headlight)) return;
            _isHeadLightEnabled = _isTailLightEnabled is false;
        }
    }
}