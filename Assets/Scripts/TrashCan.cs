using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    float detectionRadius = 0.5f;
    public bool trashIsFull;

    void Start()
    {
        trashIsFull = false;
    }

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);

        int itemCount = 0;

        // Iterate through all the colliders
        foreach (Collider collider in colliders)
        {
            // Check if the collider is a bottle
            if (collider.CompareTag("Bottle"))
            {
                // Increment the item count
                itemCount++;
            }
        }

        if (itemCount == 6)
        {
            trashIsFull = true;
        }
    }
}
