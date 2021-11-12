using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAP_ELEMENT_Finish_Line : MonoBehaviour
{
    public bool isMultilap = true;
    [Space]
    public int lap_count = 1;
    [Space]
    public bool isFinished;

    private void Start()
    {
        if (lap_count > 1)
        {
            isMultilap = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isFinished = true;
            GameObject.FindGameObjectWithTag("Ingame_Manager").GetComponent<IngameManager>().isFinished = true;
        }
    }
}
