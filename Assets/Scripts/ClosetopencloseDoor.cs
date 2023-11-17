using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class ClosetopencloseDoor : MonoBehaviour, IInteractable
	{

		public Animator Closetopenandclose;
		public bool open;
		private Transform playerTransform;

		void Start()
		{
			open = false;

			// Find the player object by tag
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			if (player != null)
			{
				playerTransform = player.transform;
			}
			else
			{
				Debug.LogError("Player not found. Make sure the player object is tagged as 'Player'.");
			}
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
			return "Click";
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


	}
}