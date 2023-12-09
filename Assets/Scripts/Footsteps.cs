using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public LayerMask woodFloorLayer;
    public LayerMask carpetLayer;

    public AudioClip woodFootstepSound;
    public AudioClip carpetFootstepSound;

    private AudioSource audioSource;

    private FirstPersonController playerMovement;

    public float timeBetweenSteps = 0.65f; // Adjust this value to set the time between footsteps
    private float nextStepTime = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.2f))
        {
            if (woodFloorLayer == (woodFloorLayer | (1 << hit.transform.gameObject.layer)))
            {
                if (GlobalVariables.isMoving && Time.time >= nextStepTime)
                {
                    PlayFootstepSound(woodFootstepSound);
                    nextStepTime = Time.time + timeBetweenSteps;
                }
            }
            else if (carpetLayer == (carpetLayer | (1 << hit.transform.gameObject.layer)))
            {
                if (GlobalVariables.isMoving && Time.time >= nextStepTime)
                {
                    PlayFootstepSound(carpetFootstepSound);
                    nextStepTime = Time.time + timeBetweenSteps;
                }
            }
        }
    }

    void PlayFootstepSound(AudioClip footstepSound)
    {
        if (!GlobalVariables.isFrozen)
        {
            if (footstepSound != null)
            {
                audioSource.clip = footstepSound;
                audioSource.Play();
            }
        }
    }
}
