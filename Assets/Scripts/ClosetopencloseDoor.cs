using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class ClosetopencloseDoor : MonoBehaviour, IInteractable
	{

		public Animator Closetopenandclose;
		private Transform playerTransform;

		public bool open;
		public bool isLocked = false;

		public AudioClip openDoor;
		public AudioClip closeDoor;
		private AudioSource audioSource;

		void Start()
		{
			open = false;
			audioSource = GetComponent<AudioSource>();
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
				return "Open";
			}
		}

		IEnumerator Opening()
		{
			print("you are opening the door");
			Closetopenandclose.Play("ClosetOpening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator Closing()
		{
			print("you are closing the door");
			Closetopenandclose.Play("ClosetClosing");
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