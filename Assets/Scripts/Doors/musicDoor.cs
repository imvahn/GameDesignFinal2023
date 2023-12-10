using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class musicDoor : MonoBehaviour, IInteractable
	{

		public Animator openandclose;
		private Transform playerTransform;

		public bool open;
		public bool isLocked;

		public AudioClip openDoor;
		public AudioClip closeDoor;
		private AudioSource audioSource;


		void Start()
		{
			open = false;
			isLocked = true;
			GlobalVariables.musicRoomLocked = true;
			audioSource = GetComponent<AudioSource>();
		}

		public void Interact()
		{
			if (!isLocked) // If it isn't locked, open and close
			{
				if (!open) //If closed, open it
				{
					GlobalVariables.musicRoomLocked = false;
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
			PlaySound(openDoor);
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator Closing()
		{
			PlaySound(closeDoor);
			print("you are closing the door");
			openandclose.Play("Closing");
			PlaySound(closeDoor);
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