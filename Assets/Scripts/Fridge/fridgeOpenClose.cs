using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class fridgeOpenClose : MonoBehaviour, IInteractable
	{

		public Animator openandclose;
		public bool open;

		public AudioClip openDoor;
		public AudioClip closeDoor;
		private AudioSource audioSource;

		public bool isLocked;


        void Start()
		{
			open = false;
			audioSource = GetComponent<AudioSource>();
			
		}

		void Update()
        {
			isLocked = GlobalVariables.fridgeIsLocked;
        }

        public void Interact()
		{
			// if key hits collider -> open
			if (GlobalVariables.fridgeIsLocked == false) // If fridge isn't locked
            {
				if (!open) //If closed, open it
				{
					StartCoroutine(Opening());
				}
				else //If open, close it
				{
					StartCoroutine(Closing());
				}
			}
		}

		public string GetDescription()
		{
			if (isLocked)
			{
				return "You cannot open this right now.";
			}
			else
			{
				if (!open)
				{
					return "Open";
				}
				else
				{
					return "Close";
				}
			}
		}

		IEnumerator Opening()
		{
			PlaySound(openDoor);
			print("you are opening the door");
			openandclose.Play("Opening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator Closing()
		{
			PlaySound(closeDoor);
			print("you are closing the door");
			openandclose.Play("Closing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}

		void PlaySound(AudioClip sound)
		{
			if (sound != null)
			{
				audioSource.clip = sound;
				audioSource.Play();
			}
		}
	}
}