using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showcase_Vehicle : MonoBehaviour
{
    public string car_name;
    [Space]
    public Vector3 rotation;
    [Space]
    public float rotation_value;

    private void Start()
    {
        rotation.y = transform.rotation.y;
    }

    private void FixedUpdate()
    {
        if (this.gameObject.activeInHierarchy)
        {
            Set_Rotation_Value();
            transform.localEulerAngles = rotation;
        }
    }

    private void Set_Rotation_Value()
    {
        rotation.y += rotation_value;
    }
}
