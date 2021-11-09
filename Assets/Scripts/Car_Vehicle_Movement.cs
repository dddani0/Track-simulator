using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Vehicle_Movement : MonoBehaviour
{
    //Source:
    //-https://asawicki.info/Mirror/Car%20Physics%20for%20Games/Car%20Physics%20for%20Games.html
    //-http://racingcardynamics.com/racing-tires-lateral-force/
    //-https://fjp.at/control/model/dynamic/dynamic-models/

    [SerializeField] private float player_vertical_input,player_horizontal_input;
    [Space]
    public float engine_force;
    public float brake_torque;
    public float deceleration_force;
    public float steer_angle;
    public float liftCoeffecient; //downforce value: MUST BE NEGATIVE
    [Space]
    public float speed = 0;
    [Space]
    public WheelCollider WheelL;
    public WheelCollider WheelR;
    public float antiRoll = 5000.0f;
    [Space]
    private Rigidbody vehicle_rigidbody;
    [Space]
    public WheelCollider front_left_drive, front_right_drive;
    public WheelCollider rear_left_drive, rear_right_drive;
    [Space]
    public Transform front_left_wheel, front_right_wheel, rear_left_wheel, rear_right_wheel;

    void Start()
    {
        vehicle_rigidbody = GetComponent<Rigidbody>();
        vehicle_rigidbody.centerOfMass += new Vector3(0f, 0f, 1.0f);
    }
    private void FixedUpdate()
    {
        Vehicle_Down_Force();
        Fetch_Player_Input();
        Drive_Acceleration();
        Anti_Roll_Bar();
        Drive_Brake();
        Drive_Steer_Drift();
    }

    private void Update()
    {

    }

    private void Anti_Roll_Bar()
    {
        WheelHit hit;
        float travelL = 1.0f;
        float travelR = 1.0f;


        bool groundedL = WheelL.GetGroundHit(out hit);

        if (groundedL)

            travelL = (-WheelL.transform.InverseTransformPoint(hit.point).y - WheelL.radius) / WheelL.suspensionDistance;

        bool groundedR = WheelR.GetGroundHit(out hit);

        if (groundedR)

            travelR = (-WheelR.transform.InverseTransformPoint(hit.point).y - WheelR.radius) / WheelR.suspensionDistance;

        float antiRollForce = (travelL - travelR) * antiRoll;

        if (groundedL)
            vehicle_rigidbody.AddForceAtPosition(WheelL.transform.up * -antiRollForce, WheelL.transform.position);

        if (groundedR)
            vehicle_rigidbody.AddForceAtPosition(WheelR.transform.up * antiRollForce, WheelR.transform.position);
    }
    private void Drive_Steer_Drift()
    {
        front_left_drive.steerAngle = steer_angle * player_horizontal_input;
        front_right_drive.steerAngle = steer_angle * player_horizontal_input;
    }
    private void Drive_Brake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rear_left_drive.brakeTorque = brake_torque;
            rear_right_drive.brakeTorque = brake_torque;
            front_left_drive.brakeTorque = brake_torque;
            front_right_drive.brakeTorque = brake_torque;
        }
    }
    private void Drive_Acceleration()
    {
        rear_left_drive.motorTorque = player_vertical_input * engine_force;
        rear_right_drive.motorTorque = player_vertical_input * engine_force;
        front_left_drive.motorTorque = player_vertical_input * engine_force;
        front_right_drive.motorTorque = player_vertical_input * engine_force;

        switch (rear_right_drive.motorTorque != 0)
        {
            case true:
                rear_left_drive.brakeTorque = 0;
                rear_right_drive.brakeTorque = 0;
                front_left_drive.brakeTorque = 0;
                front_right_drive.brakeTorque = 0;
                break;
            case false:
                rear_left_drive.brakeTorque = deceleration_force;
                rear_right_drive.brakeTorque = deceleration_force;
                front_left_drive.brakeTorque = deceleration_force;
                front_right_drive.brakeTorque = deceleration_force;
                break;
        }
    }
    private void Fetch_Player_Input()
    {
        player_vertical_input = Input.GetAxisRaw("Vertical");
        player_horizontal_input = Input.GetAxisRaw("Horizontal");
    }
    private void Vehicle_Down_Force()
    {
        if (rear_left_drive.isGrounded && rear_right_drive.isGrounded && front_left_drive.isGrounded && front_right_drive.isGrounded)
        {
            float lift = liftCoeffecient * vehicle_rigidbody.velocity.sqrMagnitude;
            vehicle_rigidbody.AddForceAtPosition(lift * transform.up, transform.position);
        }
    }
}