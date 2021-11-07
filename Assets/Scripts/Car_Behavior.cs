using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Behavior : MonoBehaviour
{
    //Source:
    //-https://asawicki.info/Mirror/Car%20Physics%20for%20Games/Car%20Physics%20for%20Games.html
    //-http://racingcardynamics.com/racing-tires-lateral-force/
    //-https://fjp.at/control/model/dynamic/dynamic-models/

    #region Basic Information
    //Basic information:
    //This script uses rear wheels to provide the drive.
    //The game will be heavy due to physics implemented.
    //We also use metric system (Kilometers, Meters ...)
    //The car needs the following forces to control the acceleration and deacceleration of the car (speed).
    //The longitude force and Lateral force are separate.
    //The car also needs angular momentum (perdület), collision and other forces which influence the car physics.
    #endregion
    #region Longitude Force
    //HANDLE: Longitude force
    //-> Lognitude force is the force, which moves the car forward and backwards
    //-> Important to keep in mind, that if the car moves forward, the wheels push backwards!
    //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    //-> So like: Car moves forward: Wheel = -force something like that
    //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    #endregion
    #region Lateral Force
    //HANDLE: Lateral force
    //-> Allows the car to turn, caused by the sideway friction of the wheels.
    #endregion
    #region  Straight line phyics
    //HANDLE: straight line physics
    //-> Tractive force: force delivired by the engine via rear wheels: rotation wise, it turns the wheels forward.
    //-> The wheels push against the opposite direction of the intended direction, and the surface pushes the wheels back, resulting in moving
    //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    //-> Formulatic way: F (traction) = unit vector (PlayerInput) * Engineforce
    //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    //-> To fight against infinite acceleration, we have calculate resistant forces (Air resistance, rolling resistance).
    //-> Air resistance is one of the most important resistance force, when we're talking about high speed car drive. It's proportional to the square of the velocity.
    //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    //-> Formulatic way: F (aerodynamic drag) = -C (constant drag) * v (velocity vector) * v.magnitude (speed)
    //-> IMPORTANT: Since we're talking about square of velocity, we have to: sqrt( var.x * var.x + v.y * v.y)
    //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    //-> Rolling resistance is the friction between the surface and the tire.
    //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    //-> Formulatic way: F (rolling resistance) = -C (constant rolling resistance) * v (speed)
    //-> Constant rolling resistance must be > constant aerodynamic drag * 30
    //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    //-> Longitudal force is the sum of these forces like:
    //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    //-> F (longitudal) = F (traction) + F (aerodynmic drag) + F (rolling resistance)
    //-> Since it's resistant forces, we're basically subtracting these forces from the traction force
    //-> When the vehicle is in stall, the vehicle is force is zero!
    //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    //-> Car's velocity is calculated using Newton's second law
    //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    //-> Formulatic way: a (acceleration) = F / M (car's mass in kilogram)
    //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
#endregion

    [SerializeField] private float player_input;
    public Rigidbody wheel_rigidbody;
    public ConstantForce vehicle_body_force;

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void FixedUpdate() 
    {
        
    }
}