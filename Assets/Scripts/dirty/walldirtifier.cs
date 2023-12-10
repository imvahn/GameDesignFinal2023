using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walldirtifier : MonoBehaviour
{
    public string t1 = "wall"; 
    public Material wallMaterial;

    public string t2 = "door";
    public Material doorMaterial;

    public string t3 = "kitchen";
    public Material kitchenMaterial;

    //public string texturePropertyName = "_MainTex"; 
    //public float maxTiling = 2f; // Maximum tiling factor for both X and Y
    //public float maxOffset = 1f; // Maximum offset factor for both X and Y


    void Start() { 
    
        GameObject[] wallMats = GameObject.FindGameObjectsWithTag(t1);
        foreach (GameObject obj in wallMats)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                
                renderer.material = wallMaterial;

       
            }
        }

        GameObject[] doorMats = GameObject.FindGameObjectsWithTag(t2);
        foreach (GameObject obj in doorMats)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = doorMaterial;
            
            }
        }

        GameObject[] kitchenTiles = GameObject.FindGameObjectsWithTag(t3);
        foreach (GameObject obj in kitchenTiles)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            renderer.material = kitchenMaterial;
            //print("p");
            //Vector2 randomTiling = new Vector2(Random.Range(1f, maxTiling), Random.Range(1f, maxTiling));
            //renderer.material.SetTextureScale(texturePropertyName, randomTiling);
            //Vector2 randomOffset = new Vector2(Random.Range(0f, maxOffset), Random.Range(0f, maxOffset));
            //renderer.material.SetTextureOffset(texturePropertyName, randomOffset);
        }
    }
}
