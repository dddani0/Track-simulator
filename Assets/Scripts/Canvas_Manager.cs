using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Manager : MonoBehaviour
{
    public GameObject Finish_Panel_GUI;
    public TMPro.TextMeshProUGUI timer_display;

    public void Set_Variable_In_Animation(GameObject gui_temp, string _action, string var_name, string var_value)
    {
        switch (_action)
        {
            case "SetTrigger":
                gui_temp.GetComponent<Animator>().SetTrigger(var_name);
                break;
            case "SetBool":
                switch (var_value)
                {
                    case "True":
                        gui_temp.GetComponent<Animator>().SetBool(var_name, true);
                        break;
                    case "False":
                        gui_temp.GetComponent<Animator>().SetBool(var_name, false);
                        break;
                }
                break;
            case "SetFloat":
                gui_temp.GetComponent<Animator>().SetFloat(var_name, float.Parse(var_name));
                break;
        }
    }

    public void Set_Text_Value(TMPro.TextMeshProUGUI text_mesh, string _text_value)
    {
        text_mesh.text = _text_value.ToString();
    }
    public void Set_Text_Value(Text _text, string _text_value)
    {
        _text.text = _text_value.ToString();
    }
}
