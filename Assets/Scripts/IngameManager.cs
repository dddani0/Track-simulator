using Car;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

internal class Timer
{
    private float _currentTimer;

    public Timer()
    {
    }

    public void IncreaseTime()
    {
        _currentTimer += Time.deltaTime;
    }

    public float GetTimer() => _currentTimer;
}

public class IngameManager : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;
    //
    private CarDrive[] _cars;

    private CarDrive _playerCar;

    //
    public KeyCode pauseGameButton;

    public KeyCode restartRunButton;

    public KeyCode headlight;

    //
    private bool _isFinished = false;

    //
    private Timer _timer;

    private void Start()
    {
        CarDrive.FinishEvent += () => _isFinished = true;
        _timer = new Timer();
        _cars = new CarDrive[GameObject.FindGameObjectsWithTag("Player")
            .Length];
        for (var index = 0; index < _cars.Length; index++)
        {
            _cars[index] = GameObject.FindGameObjectsWithTag("Player")[index].GetComponent<CarDrive>();
        }

        foreach (var car in _cars)
        {
            if (car.carOrigin.name.Contains(PlayerPrefs.GetString("car"))) _playerCar = car;
            else car.gameObject.SetActive(false);
        }

        _camera = GameObject.FindGameObjectWithTag("CinemaCam").GetComponent<CinemachineVirtualCamera>();
        var playerGameObject = _playerCar.gameObject;
        _camera.Follow = playerGameObject.transform;
        _camera.LookAt = playerGameObject.transform;
    }

    private void Update()
    {
        Timer();
        _playerCar.enabled = IsVehicleEnabled();

        return;
        bool IsVehicleEnabled() => _isFinished is false;
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
            _timer.IncreaseTime();
    }

    private void Pause()
    {
        if (Input.GetKeyDown(pauseGameButton))
            SceneManager.LoadScene("TrackSelect");
    }


    public int Speedometer() => (int)(_playerCar.CarVelocity() * 3.6f);

    public float GetTimerValue() => _timer.GetTimer();
}