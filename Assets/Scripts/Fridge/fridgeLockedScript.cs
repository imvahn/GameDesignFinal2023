using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fridgeLockedScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.fridgeIsLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Key")) {
            GlobalVariables.fridgeIsLocked = false;
            print(GlobalVariables.fridgeIsLocked);
            Destroy(gameObject);
        }

    }
}
