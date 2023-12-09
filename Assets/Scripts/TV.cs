using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TV : MonoBehaviour
{

    public GameObject HoldArea;
    public DigitalScreen Screen;
    public Material TVOn;
    public Material TVOff;

    void Start()
    {
        GlobalVariables.TVisOn = false;
    }

    void Update()
    {
        if (GlobalVariables.TVisOn) // If TVisOn is true, turn the TV on.
        {
            Screen.ChangeMaterial(TVOn);
        }
        else
        {
            Screen.ChangeMaterial(TVOff);
        }
    }
}
