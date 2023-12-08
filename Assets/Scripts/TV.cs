using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TV : MonoBehaviour, IInteractable
{

    public GameObject HoldArea;
    public DigitalScreen Screen;
    public Material TVOn;
    public Material TVOff;
    private bool TVisOn;

    void Start()
    {
        TVisOn = false;
    }

    public void Interact()
    {
        if (HoldArea.GetComponentInChildren<Remote>())
        {
            if (!TVisOn)
            {
                Screen.ChangeMaterial(TVOn);
                TVisOn = true;
            }
            else
            {
                Screen.ChangeMaterial(TVOff);
                TVisOn = false;
            }
        }
    }
   public string GetDescription()
    {
        if (HoldArea.GetComponentInChildren<Remote>())
        {
            if (!TVisOn)
            {
                return "Turn On TV";
            }
            else
            {
                return "Turn Off TV";
            }
        }

        return "Need Remote";
    }
}
