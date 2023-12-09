using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InspirationPills : MonoBehaviour, IInteractable
{
    public GameObject Gchord;
    public GameObject BflatChord;
    public GameObject AminChord;
    public GameObject FmajChord;

    public void Start()
    {

    }

    public void Interact()
    {
        postProcessingEnable.instance.TurnOnInspiration();
        Gchord.GetComponent<TMPro.TMP_Text>().color = Color.red;
        BflatChord.GetComponent<TMPro.TMP_Text>().color = Color.red;
        AminChord.GetComponent<TMPro.TMP_Text>().color = Color.red;
        FmajChord.GetComponent<TMPro.TMP_Text>().color = Color.red;
    }

    public string GetDescription()
    {
        return "Take Inspiration Pills";
    }
}
