using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{

	public class Drawer_Pull_X : MonoBehaviour, IInteractable
	{

		public Animator pull_01;
		public bool open;

		public AudioClip openCabinet;
		public AudioClip closeCabinet;
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
			print("you are opening the door");
			pull_01.Play("openpull_01");
			PlaySound(openCabinet);
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator Closing()
		{
			print("you are closing the door");
			pull_01.Play("closepush_01");
			PlaySound(closeCabinet);
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