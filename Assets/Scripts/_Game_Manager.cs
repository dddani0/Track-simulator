﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Game_Manager : MonoBehaviour
{
    public GameObject property_fetcher;

    private void Start()
    {
        GameObject temp_inst;
        if (GameObject.FindGameObjectWithTag("Property_Fetcher") == null)
        {
            temp_inst = Instantiate(property_fetcher);
        }
        if (property_fetcher != null)
        {
            property_fetcher = GameObject.FindGameObjectWithTag("Property_Fetcher");
        }
    }
}