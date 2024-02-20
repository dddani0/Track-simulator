using System;
using System.Linq;
using Car;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameManager : MonoBehaviour
{
    private CarDrive[] _cars;

    private CarDrive _playerCar;

    //
    public KeyCode pauseGameButton;

    public KeyCode restartRunButton;

    //
    private bool _isFinished = false;

    //
    [SerializeField] private float timer;

    private void Start()
    {
        timer = 0;
        _cars = new CarDrive[GameObject.FindGameObjectsWithTag("Player")
            .Length]; //ezt linq expressionbe szeretném átírni
        for (var index = 0; index < _cars.Length; index++)
        {
            _cars[index] = GameObject.FindGameObjectsWithTag("Player")[index].GetComponent<CarDrive>();
        }

        Debug.Log(PlayerPrefs.GetString("car"));
        foreach (var car in _cars)
        {
            if (car.carOrigin.name.Contains(PlayerPrefs.GetString("car"))) _playerCar = car;
            else car.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        Timer();
    }

    private void LateUpdate()
    {
        Restart();
        Pause();
    }

    private void Restart()
    {
        if (!Input.GetKeyDown(restartRunButton)) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Timer()
    {
        if (!_isFinished)
            timer += (1 * Time.fixedDeltaTime);
    }

    private void Pause()
    {
        if (Input.GetKeyDown(pauseGameButton))
            SceneManager.LoadScene("TrackSelect");
    }


    public int Speedometer() => (int)(_playerCar.CarVelocity() * 3.6f);
}