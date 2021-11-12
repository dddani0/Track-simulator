using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Vehicle_Miscellaneous : MonoBehaviour
{
    public GameObject ingame_Manager;
    [Space]
    public KeyCode headlight_switch_button;
    public KeyCode camera_switch_button;
    [Space]
    private bool is_headlight_on = false;
    [Space]
    public GameObject[] headlights;
    public GameObject[] tail_lamps;
    [Space]
    public float _player_vertical_input;
    [Space]
    public GameObject[] cameras;
    private int camera_index = 0;


    private void Start()
    {
        ingame_Manager = GameObject.FindGameObjectWithTag("Ingame_Manager");
        for (int i = 0; i < tail_lamps.Length; i++)
        {
            tail_lamps[i].SetActive(false);
        }
        for (int i = 0; i < headlights.Length; i++)
        {
            headlights[i].SetActive(false);
        }
        is_headlight_on = false;
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
        }
    }

    private void Update()
    {
        Camera_Pov_Switch();
        Fetch_Headlight_Information_To_Display();
    }

    private void LateUpdate()
    {
        Switch_Headlight_State();
    }

    private void Camera_Pov_Switch()
    {
        if (Input.GetKeyDown(camera_switch_button))
        {
            switch (camera_index < cameras.Length - 1)
            {
                case true:
                    cameras[camera_index].SetActive(false);
                    camera_index++;

                    break;
                case false:
                    cameras[camera_index].SetActive(false);
                    camera_index = 0;
                    break;
            }
            cameras[camera_index].SetActive(true);
        }
    }

    private void Switch_Headlight_State()
    {
        switch (is_headlight_on)
        {
            case true:
                if (Input.GetKeyDown(headlight_switch_button))
                {
                    headlights[0].SetActive(false);
                    headlights[1].SetActive(false);
                    is_headlight_on = false;
                }
                break;
            case false:
                if (Input.GetKeyDown(headlight_switch_button))
                {
                    headlights[0].SetActive(true);
                    headlights[1].SetActive(true);
                    is_headlight_on = true;
                }
                break;
        }
    }

    private void Fetch_Headlight_Information_To_Display()
    {
        switch (_player_vertical_input < 0)
        {
            case true:
                //Try somekind of loop, but only go thru the loop if bool allows
                //Bool = break function
                tail_lamps[0].SetActive(true);
                tail_lamps[1].SetActive(true);
                break;
            case false:
                tail_lamps[0].SetActive(false);
                tail_lamps[1].SetActive(false);
                break;
        }
    }
}
