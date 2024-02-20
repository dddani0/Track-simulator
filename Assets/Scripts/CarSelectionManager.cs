using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelectionManager : MonoBehaviour
{
    private CarShowcase[] _cars;

    private CarShowcase _selectedCar;

    //
    public float carRotationSpeed;

    private int _carIdx = 0;

    private void Start()
    {
        _cars = GameObject.FindGameObjectsWithTag("ShowcaseCar").Select(s => s.GetComponent<CarShowcase>()).ToArray();
        foreach (var car in _cars)
        {
            car.gameObject.SetActive(false);
        }

        _cars[_carIdx].gameObject.SetActive(true);
        SetCar(_carIdx);
    }

    public void IncrementCarDisplay()
    {
        _cars[_carIdx].gameObject.SetActive(false);
        _carIdx++;
        if (_carIdx > _cars.Length - 1) _carIdx = 0;
        _cars[_carIdx].gameObject.SetActive(true);
        SetCar(_carIdx);
    }

    public void DecrementCarDisplay()
    {
        _cars[_carIdx].gameObject.SetActive(false);
        _carIdx--;
        if (_carIdx < 0) _carIdx = _cars.Length - 1;
        _cars[_carIdx].gameObject.SetActive(true);
        SetCar(_carIdx);
    }

    private void SetCar(int carIndex)
    {
        _selectedCar = _cars[carIndex];
    }

    public void SelectCurrentCar()
    {
        PlayerPrefs.SetString("car", GetSelectedCar().carOrigion.name);
        SceneManager.LoadScene("TrackSelect");
    }

    public CarShowcase GetSelectedCar() => _selectedCar;
}