using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;

public class FinalSongInput : MonoBehaviour
{
    
    TMP_InputField chordInput;
    public bool isCorrect;

    private void Start()
    {
        isCorrect = false;
        chordInput = GetComponent<TMP_InputField>();
    }

    public void CheckChord(string correctChord)
    {
        if (chordInput.text == correctChord)
        {
            isCorrect = true;
        }
        else { isCorrect = false; }
    }
}
