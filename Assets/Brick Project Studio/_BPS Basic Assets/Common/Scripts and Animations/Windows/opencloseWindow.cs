using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class opencloseWindow : MonoBehaviour
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

		void OnMouseOver()
		{
			{
				if (playerTransform)
				{
					float dist = Vector3.Distance(playerTransform.position, transform.position);
					if (dist < 15)
					{
						if (open == false)
						{
							if (Input.GetMouseButtonDown(0))
							{
								StartCoroutine(opening());
							}
						}
						else
						{
							if (open == true)
							{
								if (Input.GetMouseButtonDown(0))
								{
									StartCoroutine(closing());
								}
							}

						}

					}
				}

			}

		}

		IEnumerator opening()
		{
			print("you are opening the Window");
			openandclosewindow.Play("Openingwindow");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the Window");
			openandclosewindow.Play("Closingwindow");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}