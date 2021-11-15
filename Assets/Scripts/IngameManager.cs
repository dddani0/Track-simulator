using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameManager : MonoBehaviour
{
    public Canvas_Manager canvasmanager;
    [Space]
    public string scenename;
    [Space]
    public GameObject player_car;
    public List<GameObject> car_selection;
    [Space]
    public List<GameObject> map_elements;
    [Space]
    public KeyCode pause_game_button;
    public KeyCode restart_run_button;
    [Space]
    public TMPro.TextMeshProUGUI map_name_display;
    public TMPro.TextMeshProUGUI car_speed_display;
    [Space]
    public bool isPaused = false;
    public bool isFinished = false;
    [Space]
    public float timer_start = -3;
    [SerializeField] private float timer;
    [Space]
    public TMPro.TextMeshProUGUI timer_display;

    private void Start()
    {
        Evaluate_Default_Properties_Variables();
    }

    private void Update()
    {
        Speed_O_Meter(player_car.GetComponent<Rigidbody>().velocity.magnitude * 3.6f);
        canvasmanager.Set_Variable_In_Animation(canvasmanager.Finish_Panel_GUI, "SetBool", "is_Finished", isFinished.ToString());
    }
    private void FixedUpdate()
    {
        Timer_Display();
    }

    private void LateUpdate()
    {
        Restart_Run();
        Pause_Game();
        Player_Finish_Check();
    }

    private void Evaluate_Default_Properties_Variables()
    {
        timer = timer_start;
        map_elements.AddRange(GameObject.FindGameObjectsWithTag("MAP_ELEMENT"));
        scenename = SceneManager.GetActiveScene().name;
        Display_Track_Name();
        car_selection.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        foreach (var item in car_selection)
        {
            if (!item.name.Contains(GameObject.FindGameObjectWithTag("Property_Fetcher").GetComponent<Game_Properties>().selected_car))
                item.SetActive(false);
            else
                player_car = item;
        }
    }

    private void Restart_Run()
    {
        if (Input.GetKeyDown(restart_run_button))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Timer_Display()
    {
        if (!isFinished)
            timer += 1 * Time.fixedDeltaTime;
        timer_display.text = Mathf.Round(Mathf.Abs(timer)).ToString();
    }

    private void Display_Track_Name()
    {
        if (map_name_display != null)
            map_name_display.text = ("Track: " + scenename).ToString();
        else
            Debug.LogError("VAR UNASSIGNED: map_name_display");
    }

    private void Player_Finish_Check()
    {
        if (isFinished)
        {
            player_car.GetComponent<Car_Vehicle_Movement>().deceleration_force *= 200;
            player_car.GetComponent<Car_Vehicle_Movement>().steer_angle = 0;
            player_car.GetComponent<Car_Vehicle_Movement>().engine_force = 0;
            canvasmanager.timer_display.text = $"Time: {Mathf.Round(timer)} seconds!".ToString();
        }
    }

    private void Pause_Game()
    {
        if (Input.GetKeyDown(pause_game_button))
            SceneManager.LoadScene("Track_Select");
    }

    private void Speed_O_Meter(float _speed)
    {
        if (car_speed_display != null)
        {
            car_speed_display.text = Mathf.RoundToInt(_speed).ToString();
        }
        else
        {
            Debug.LogError("VAR UNASSIGNED: car_speed_display");
        }
    }
}
