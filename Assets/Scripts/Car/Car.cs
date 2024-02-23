using UnityEngine;
using UnityEngine.Serialization;

namespace Car
{
    [CreateAssetMenu(fileName = "Car", menuName = "ScriptableObjects/car", order = 1)]
    public class Car : ScriptableObject
    {
        public new string name;
        public string description;
        public float acceleration;
        [FormerlySerializedAs("decceleration")] public float deceleration;
        public float steer;
        public float brake;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public float Acceleration
        {
            get => acceleration;
            set => acceleration = value;
        }

        public float Decceleration
        {
            get => deceleration;
            set => deceleration = value;
        }

        public float Steer
        {
            get => steer;
            set => steer = value;
        }

        public float Brake
        {
            get => brake;
            set => brake = value;
        }
        
    }
}