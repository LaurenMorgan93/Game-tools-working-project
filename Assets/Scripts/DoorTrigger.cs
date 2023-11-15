using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private Animator doorAnim;
    private bool DoorOpen;

    private void Start()
    {
        // Make sure to reference the Animator component of the GameObject containing the door animation.
        doorAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player") && !DoorOpen)
        {
            // Trigger the "Open" animation if the player enters the trigger zone.
            doorAnim.SetTrigger("Open");
            DoorOpen = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
         if (other.gameObject.tag == ("Player") && DoorOpen)
        {
            // Trigger the "Open" animation if the player enters the trigger zone.
            doorAnim.SetTrigger("Close");
            DoorOpen = false;
        }

    }



}
