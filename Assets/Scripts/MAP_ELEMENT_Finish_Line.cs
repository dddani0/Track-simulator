using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAP_ELEMENT_Finish_Line : MonoBehaviour
{
    public bool isMultilap = true;
    [Space]
    public int lap_count = 1;
    public int current_lap = 0;
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
        switch (isMultilap)
        {
            case true:
                switch (current_lap < lap_count)
                {
                    case true:
                        if (other.tag == "Player")
                        {
                            current_lap++;
                        }
                        break;
                    case false:
                        if (other.tag == "Player")
                        {
                            current_lap++;
                            isFinished = true;
                            GameObject.FindGameObjectWithTag("Ingame_Manager").GetComponent<IngameManager>().isFinished = true;
                        }
                        break;
                }
                break;
            case false:
                if (other.tag == "Player")
                {
                    isFinished = true;
                    GameObject.FindGameObjectWithTag("Ingame_Manager").GetComponent<IngameManager>().isFinished = true;
                }
                break;
        }
    }
}
