using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class opencloseDoor1 : MonoBehaviour, IInteractable
	{

		public Animator openandclose1;

		public bool open;
		public bool isLocked = false;

		public AudioClip openDoor;
		public AudioClip closeDoor;
		private AudioSource audioSource;

		void Start()
		{
			audioSource = GetComponent<AudioSource>();
			open = false;
		}

		public void Interact()
		{
			if (!isLocked) //If it isn't locked, open and close
			{
				if (!open) //If closed, open it
				{
					StartCoroutine(Opening());
				}
				else //If open, close it
				{
					StartCoroutine(Closing());
				}
			}//If it is locked, do nothing
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
			openandclose1.Play("Opening 1");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator Closing()
		{
			PlaySound(closeDoor);
			print("you are closing the door");
			openandclose1.Play("Closing 1");
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