using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public OxygenBar oxygenManagementScript;
    public AudioManager audioScript;
    public GameObject Collectable1;
    public GameObject Collectable2;
    public GameObject Collectable3;

    void Start()
    {
        oxygenManagementScript = FindObjectOfType<OxygenBar>();
        Collectable1.SetActive(true);
        Collectable2.SetActive(true);
        Collectable3.SetActive(true);

        // Load the player's position from PlayerPrefs and respawn them
        RespawnPlayer();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "SafeZone")
        {
            Debug.Log(other.gameObject.tag);
            oxygenManagementScript.InSafeZone = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SafeZone")
        {
            oxygenManagementScript.InSafeZone = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            Debug.Log("Picked up " + other.gameObject.name);
            if (other.gameObject.name == "chip")
            {
                audioScript.PlayAudioClip("Collect");
                Collectable1.SetActive(false);
            }
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Mine")
        {
            oxygenManagementScript.MineOxygenDecrease(50);
            audioScript.PlayAudioClip("Explode");
            Destroy(other.gameObject);
        }
    }

    // Add this method to respawn the player at the last checkpoint
  public   void RespawnPlayer()
    {
        float playerPosX = PlayerPrefs.GetFloat("PlayerPosX");
        float playerPosY = PlayerPrefs.GetFloat("PlayerPosY");
        float playerPosZ = PlayerPrefs.GetFloat("PlayerPosZ");

        Vector3 respawnPosition = new Vector3(playerPosX, playerPosY, playerPosZ);

        transform.position = respawnPosition;
    }
}
