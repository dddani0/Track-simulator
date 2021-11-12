using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showcase_Vehicle : MonoBehaviour
{
    /// <summary>
    /// Appears in the Car_Selection scene
    /// -Rotates the car with x values
    /// -stores car name
    /// </summary>

    public string car_name;
    [Space]
    public Vector3 rotation;
    [Space]
    public float rotation_value;
    [SerializeField] private float rotation_default_value;

    private void Start()
    {
        rotation.y = transform.rotation.y;
        rotation_default_value = rotation.y;
    }

    private void FixedUpdate()
    {
        if (this.gameObject.activeInHierarchy)
        {
            Set_Rotation_Value();
            transform.localEulerAngles = rotation;
        }
        else
        {
            rotation.y = rotation_default_value;
        }
    }

    private void Set_Rotation_Value()
    {
        rotation.y += rotation_value;
    }
}
