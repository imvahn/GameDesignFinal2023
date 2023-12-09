using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class opencloseWindow1 : MonoBehaviour, IInteractable
	{

		public Animator openandclosewindow1;
		public bool open;
		private Transform playerTransform;

		void Start()
		{
			open = false;
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
			openandclosewindow1.Play("Openingwindow 1");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator Closing()
		{
			print("you are closing the Window");
			openandclosewindow1.Play("Closingwindow 1");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}