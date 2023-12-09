using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class opencloseWindow : MonoBehaviour, IInteractable
	{

		public Animator openandclosewindow;
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
			print("you are opening the Window");
			openandclosewindow.Play("Openingwindow");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator Closing()
		{
			print("you are closing the Window");
			openandclosewindow.Play("Closingwindow");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}