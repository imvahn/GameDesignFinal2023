using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class editTextColor : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTextColor(Color newColor)
    {
        // Change the color of the TextMeshPro component
        textMeshPro.color = newColor;
    }
}
