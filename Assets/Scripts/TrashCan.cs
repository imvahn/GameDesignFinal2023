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
            // Check if the collider has the specified tag
            if (collider.CompareTag("Bottle"))
            {
                // Increment the item count
                itemCount++;
                print(itemCount);
            }
        }

        if (itemCount == 10)
        {
            trashIsFull = true;
        }
    }

/*    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bottle"))
        {
            other.transform.SetParent(transform);
        }
    }

    public int CountItemsInBin()
    {
        int itemCount = transform.childCount;
        return itemCount;
    }*/
}
