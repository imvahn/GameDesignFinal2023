using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class BRGlassDoor : MonoBehaviour, IInteractable
	{

		public Animator openandclose;
		public bool open;

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
			if (!open) //If closed, open it
			{
				StartCoroutine(Opening());
			}
			else //If open, close it
			{
				StartCoroutine(Closing());
			}
		}

		public string GetDescription()
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

		IEnumerator Opening()
		{
			print("you are opening");
			openandclose.Play("BRGlassDoorOpen");
			PlaySound(openDoor);
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator Closing()
		{
			print("you are closing");
			openandclose.Play("BRGlassDoorClose");
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