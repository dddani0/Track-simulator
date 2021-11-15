using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void LoadScene(string scenename)
    {
        if (SceneManager.GetSceneByName(scenename) != null)
            SceneManager.LoadScene(scenename);
        else
            Debug.LogError($"VAR NULL: {scenename} is non-existant.");
    }

    public void Change_Selected_Car(int delta_num)
    {
        GameObject.FindGameObjectWithTag("Car_Selection_Manager").GetComponent<Car_Selection_Display>().Change_Car_On_Display(delta_num);
    }

    public void Exit_Game()
    {
        Application.Quit();
    }
}
