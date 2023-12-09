using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspirationPills : MonoBehaviour, IInteractable
{
    
    public void Interact()
    {
        postProcessingEnable.instance.TurnOnInspiration();
        editTextColor.ChangeTextColor(Color.red);
    }

    public string GetDescription()
    {
        return "Take Inspiration Pills";
    }
}
