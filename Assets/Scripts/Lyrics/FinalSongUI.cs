using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinalSongUI : MonoBehaviour
{
    public FinalSongInput GMaj7;
    public FinalSongInput BbMaj7;
    public FinalSongInput AMaj7;
    public FinalSongInput FMaj7;

    public GameObject win;

    private void Start()
    {
        win.SetActive(false);
    }

    private void Update()
    {
        if(GMaj7.isCorrect && BbMaj7.isCorrect && AMaj7.isCorrect && FMaj7.isCorrect)
        {
            win.SetActive(true);
        }
    }


}
