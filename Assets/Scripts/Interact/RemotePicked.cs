using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemotePicked : MonoBehaviour, IInteractable
{

    private Rigidbody rb;

    public GameObject E;
    public GameObject LEFTCLICK;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        E.SetActive(!GlobalVariables.remoteHeld); // E set active when remote is NOT pointing at TV
        LEFTCLICK.SetActive(GlobalVariables.remoteHeld); // LEFTCLICK set active when remote is pointing at TV
    }

    public void Interact()
    {

    }

    public string GetDescription()
    {
        if (rb.useGravity) // If the object is not being picked up
        {
            return "Pick Up";
        }
        else
        {
            if (GlobalVariables.remoteHeld) // If remote is pointing at tv
            {
                if (GlobalVariables.TVisOn) // If TV is on
                {
                    return "Turn off TV";
                }
                else
                {
                    return "Turn on TV";
                }
            }
            else
            {
                return "Put Down";
            }
        }
    }
}
