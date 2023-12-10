using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using SojaExiles;
using TMPro;
using UnityEngine;

public class KeypadUI : MonoBehaviour
{
    string code = "1824";
    string input = "";
    public TMP_Text output = null;
    public musicDoor musicRoomDoor;

    private void Start()
    {
        musicRoomDoor.isLocked = true;
        output.text = "****";
    }

    public void TakeInput(string numbers)
    {
        input = input + numbers;
        output.text = input;
    }

    public void Enter()
    {
        if (input == code)
        {
            output.text = "Correct";
            musicRoomDoor.isLocked = false; //unlock door
            input = null;
        }
        else
        {
            output.text = "Incorrect";
            input = null;
        }
    }

    public void Clear()
    {
        input = null;
        output.text = "";
    }
}
