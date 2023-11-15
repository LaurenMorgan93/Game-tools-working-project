using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenPoint : MonoBehaviour
{

    public AudioManager audioScript;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player is within the oxygen point trigger
            // Call the method in OxygenBar to restore oxygen
            OxygenBar oxygenBar = FindObjectOfType<OxygenBar>();
            if (oxygenBar != null)
            {
                oxygenBar.RestoreOxyAtCheckpoint();
            }
        }
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Store the player's position in PlayerPrefs
            //PlayerPrefs.SetFloat("PlayerPosX", other.transform.position.x);
            //PlayerPrefs.SetFloat("PlayerPosY", other.transform.position.y);
            //PlayerPrefs.SetFloat("PlayerPosZ", other.transform.position.z);
            PlayOxyUPSound();



        }
    }


    public void PlayOxyUPSound()
    {
        audioScript.PlayAudioClip("Oxy");

    }
}
