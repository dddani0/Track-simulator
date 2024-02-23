using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Car
{
    public class CarDrive : MonoBehaviour
    {
        public Car carOrigin;
        [FormerlySerializedAs("player_vertical_input")] [SerializeField]
        private float verticalInput;
        [FormerlySerializedAs("player_horizontal_input")] [SerializeField]
        private float horizontalInput;
        private const float LiftCoeffecient = -5; //downforce value: MUST BE NEGATIVE
        [FormerlySerializedAs("WheelL")] [Space]
        public WheelCollider wheelL;
        [FormerlySerializedAs("WheelR")] public WheelCollider wheelR;
        public float antiRoll = 5000.0f;
        [Space] private Rigidbody _vehicleRigidbody;
        [FormerlySerializedAs("front_left_drive")] [Space]
        public WheelCollider frontLeftDrive;
        [FormerlySerializedAs("front_right_drive")] [Space]
        public WheelCollider frontRightDrive;
        [FormerlySerializedAs("rear_left_drive")]
        public WheelCollider rearLeftDrive;
        [FormerlySerializedAs("rear_right_drive")]
        public WheelCollider rearRightDrive;
        //
        public  delegate void CarEvent();

        public static event CarEvent FinishEvent;
        
        private void Start()
        {
            if (carOrigin is null)
                Debug.LogError("Car object is not assigned!");
            _vehicleRigidbody = GetComponent<Rigidbody>();
            _vehicleRigidbody.centerOfMass += new Vector3(0f, 0f, 1.0f);
        }
        
        private void FixedUpdate()
        {
            DownForce();
            AntiRollBar();
            //
            PlayerInput();
            //
            TorqueDrive();
            Brake();
            Steer();
        }

        private void AntiRollBar()
        {
            WheelHit hit;
            var travelL = 1.0f;
            var travelR = 1.0f;


            var groundedL = wheelL.GetGroundHit(out hit);

            if (groundedL)

                travelL = (-wheelL.transform.InverseTransformPoint(hit.point).y - wheelL.radius) /
                          wheelL.suspensionDistance;

            var groundedR = wheelR.GetGroundHit(out hit);

            if (groundedR)

                travelR = (-wheelR.transform.InverseTransformPoint(hit.point).y - wheelR.radius) /
                          wheelR.suspensionDistance;

            var antiRollForce = (travelL - travelR) * antiRoll;

            if (groundedL)
                _vehicleRigidbody.AddForceAtPosition(wheelL.transform.up * -antiRollForce, wheelL.transform.position);

            if (groundedR)
                _vehicleRigidbody.AddForceAtPosition(wheelR.transform.up * antiRollForce, wheelR.transform.position);
        }

        private void Steer()
        {
            frontLeftDrive.steerAngle = carOrigin.Steer * horizontalInput;
            frontRightDrive.steerAngle = carOrigin.Steer * horizontalInput;
        }

        private void Brake()
        {
            if (!Input.GetKey(KeyCode.Space)) return; //Régi input system xd
            rearLeftDrive.brakeTorque = carOrigin.Brake;
            rearRightDrive.brakeTorque = carOrigin.Brake;
            frontLeftDrive.brakeTorque = carOrigin.Brake;
            frontRightDrive.brakeTorque = carOrigin.Brake;
        }

        private void TorqueDrive()
        {
            rearLeftDrive.motorTorque = verticalInput * carOrigin.Acceleration;
            rearRightDrive.motorTorque = verticalInput * carOrigin.Acceleration;
            frontRightDrive.motorTorque = verticalInput * carOrigin.Acceleration;
            frontLeftDrive.motorTorque = verticalInput * carOrigin.Acceleration;

            switch (frontRightDrive.motorTorque != 0)
            {
                case true:
                    rearLeftDrive.brakeTorque = 0;
                    rearRightDrive.brakeTorque = 0;
                    frontLeftDrive.brakeTorque = 0;
                    frontRightDrive.brakeTorque = 0;
                    break;
                case false:
                    rearLeftDrive.brakeTorque = carOrigin.Decceleration;
                    rearRightDrive.brakeTorque = carOrigin.Decceleration;
                    frontLeftDrive.brakeTorque = carOrigin.Decceleration;
                    frontRightDrive.brakeTorque = carOrigin.Decceleration;
                    break;
            }
        }

        private void PlayerInput()
        {
            verticalInput = Input.GetAxisRaw("Vertical");
            horizontalInput = Input.GetAxisRaw("Horizontal");
        }

        private void DownForce()
        {
            if (!rearLeftDrive.isGrounded || !rearRightDrive.isGrounded || !frontLeftDrive.isGrounded ||
                !frontRightDrive.isGrounded) return;
            var lift = LiftCoeffecient * _vehicleRigidbody.velocity.sqrMagnitude;
            _vehicleRigidbody.AddForceAtPosition(lift * transform.up, transform.position);
        }

        public float CarVelocity() => _vehicleRigidbody.velocity.magnitude;
        public float VerticalInput() => verticalInput;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("FinishLine")) FinishEvent?.Invoke();
        }
    }
}