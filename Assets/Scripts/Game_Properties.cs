using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Properties : MonoBehaviour
{
    public string selected_car;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
