using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class Drawer_Pull_Z : MonoBehaviour
	{

		public Animator pull;
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
					if (dist < 10)
					{
						print("object name");
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
			print("you are opening the door");
			pull.Play("openpull");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			pull.Play("closepush");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}