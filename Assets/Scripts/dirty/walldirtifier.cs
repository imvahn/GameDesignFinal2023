using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walldirtifier : MonoBehaviour
{
    public string targetTag1 = "wall"; // Replace "YourTag" with the actual tag you want to search for
    public Material wallMaterial;

    public string targetTag2 = "door";
    public Material doorMaterial;


    void Start()
    {
        // Find all game objects with the specified tag
        GameObject[] objectsInLayer = GameObject.FindGameObjectsWithTag(targetTag1);

        // Iterate through the found game objects
        foreach (GameObject obj in objectsInLayer)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                
                renderer.material = wallMaterial;
            }
        }
        GameObject[] objectsInLayer2 = GameObject.FindGameObjectsWithTag(targetTag2);
        foreach (GameObject obj in objectsInLayer2)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {

                print("pot");

                renderer.material = doorMaterial;
            }
        }
    }
}
