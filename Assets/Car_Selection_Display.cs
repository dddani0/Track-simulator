using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Selection_Display : MonoBehaviour
{
    public GameObject[] showcase_Vehicle_Selection;
    [Space]
    public int index = 0;

    private void Start()
    {
        foreach (var item in showcase_Vehicle_Selection)
        {
            item.SetActive(false);
        }
        showcase_Vehicle_Selection[index].SetActive(true);
        GameObject.FindGameObjectWithTag("Property_Fetcher").GetComponent<Game_Properties>().selected_car = showcase_Vehicle_Selection[index].GetComponent<Showcase_Vehicle>().car_name;
    }

    public void Change_Car_On_Display(int cDelta)
    {
        showcase_Vehicle_Selection[index].SetActive(false);

        if (index < showcase_Vehicle_Selection.Length - 1)
            index += cDelta;
        else if (index == showcase_Vehicle_Selection.Length - 1)
            index = 0;
        showcase_Vehicle_Selection[index].SetActive(true);
        GameObject.FindGameObjectWithTag("Property_Fetcher").GetComponent<Game_Properties>().selected_car = showcase_Vehicle_Selection[index].GetComponent<Showcase_Vehicle>().car_name;
    }
}
