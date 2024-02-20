using System;
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
    }

    private void Update()
    {
        speedOMeterDisplay.text = _ingameManager.Speedometer().ToString();
    }
}