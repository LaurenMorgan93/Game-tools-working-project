using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public OxygenBar oxygenManagementScript;
    public SceneMover sceneChangingScript;
    public AudioManager audioScript;
    public GameObject Collectable1;
    public GameObject Collectable2;
    public GameObject Collectable3;
    public GameObject chipUISprite;
    public GameObject wrenchUISprite;
    public GameObject GyroUISprite;
    public GameObject RocketStatusPanel;
    private bool allItemsCollected;
    public TextMeshProUGUI rocketText;

    void Start()
    {
        oxygenManagementScript = FindObjectOfType<OxygenBar>();
        
        Collectable1.SetActive(true);
        Collectable2.SetActive(true);
        Collectable3.SetActive(true);
        chipUISprite.SetActive(true);
        wrenchUISprite.SetActive(true);
        GyroUISprite.SetActive(true);
        RocketStatusPanel.SetActive(false);

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

        if(other.gameObject.tag == "Rocket")
        {
            RocketStatusPanel.SetActive(false);
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
                chipUISprite.SetActive(false);
                Destroy(other.gameObject);
            }
            
            if(other.gameObject.name == "Wrench")
            {
                audioScript.PlayAudioClip("Collect");
                Collectable2.SetActive(false);
               wrenchUISprite.SetActive(false);
                Destroy(other.gameObject);
            }

            if (other.gameObject.name == "Gyro")
            {
                audioScript.PlayAudioClip("Collect");
                Collectable3.SetActive(false);
                GyroUISprite.SetActive(false);
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.tag == "Mine")
        {
            oxygenManagementScript.MineOxygenDecrease(50);
            audioScript.PlayAudioClip("Explode");
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Rocket")
        {
            RocketStatusPanel.SetActive(true);
            rocketText.text = "Warning! Repair Parts Needed";

            if (allItemsCollected)
            {
                SceneManager.LoadScene("Final Cutscene");

            }
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
