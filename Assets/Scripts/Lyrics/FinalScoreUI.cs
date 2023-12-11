using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScoreUI : MonoBehaviour
{

    public GameObject WinUI;
    public FinalSongInput GMaj7;
    public FinalSongInput BbMaj7;
    public FinalSongInput AMaj7;
    public FinalSongInput FMaj7;


    private void Start()
    {
        WinUI.SetActive(false);
    }

    private void Update()
    {
        if (GMaj7.isCorrect && BbMaj7.isCorrect && AMaj7.isCorrect && FMaj7.isCorrect)
        {
            WinUI.SetActive(true);

        }
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
        
    }


}
