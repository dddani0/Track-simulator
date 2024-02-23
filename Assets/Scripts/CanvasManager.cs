using System;
using Car;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    private IngameManager _ingameManager;
    public GameObject victoryPanelElement;
    public TMPro.TextMeshProUGUI timerDisplay;
    //
    public TMPro.TextMeshProUGUI speedOMeterDisplay;

    private void Start()
    {
        _ingameManager = GameObject.FindGameObjectWithTag("IngameManager").GetComponent<IngameManager>();
        CarDrive.FinishEvent += EnableVictoryScreen;
    }

    private void Update()
    {
        speedOMeterDisplay.text = _ingameManager.Speedometer().ToString();
        timerDisplay.text = $"Timer: {Mathf.RoundToInt(_ingameManager.GetTimerValue()).ToString()}";
    }

    private void EnableVictoryScreen()
    {
        victoryPanelElement.SetActive(true);
    }
}