using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class bedroomDoor : MonoBehaviour, IInteractable
	{

		public Animator openandclose;
		public bool open;
		public bool isLocked;
		public TrashCan trashCan;
		public Phone phone;

		void Start()
		{
			open = false;
			isLocked = true;
		}

        public void Update()
        {
            if (phone.hasDisplayedOnce && trashCan.trashIsFull)
            {
                isLocked = false;
            }
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
			openandclose.Play("Opening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator Closing()
		{
			print("you are closing the door");
			openandclose.Play("Closing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}