using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using SojaExiles;
using TMPro;
using UnityEngine;

public class KeypadUI : MonoBehaviour
{
    string code = "1824";
    string input = null;
    public TMP_Text output = null;
    public opencloseDoor musicRoomDoor;

    private void Start()
    {
        musicRoomDoor.isLocked = true;
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
}
