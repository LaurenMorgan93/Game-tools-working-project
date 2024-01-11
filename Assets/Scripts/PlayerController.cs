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
    public bool wrenchCollected;
    public bool gyroCollected;
    public bool chipCollected;
    public TextMeshProUGUI rocketText;

    public Vector3 checkpoint;
    public Vector3 tempCheckpoint;
    public OxygenBar oxygenLevel;
    public GameObject doomPanel;
    public GameObject oxyDeathPanel;





    void Start()
    {
        //oxygenLevel = GetComponent<OxygenBar>();

        //uniqueCheckpoint = FindGameObjectsWithTag("oxyegnPoint");
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

    public void Update()
    {
      
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "SafeZone")
        {
            //Debug.Log(other.gameObject.tag);
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
                chipCollected = true;
                Destroy(other.gameObject);
                checkForCompletion();
            }
            
            if(other.gameObject.name == "Wrench")
            {
                audioScript.PlayAudioClip("Collect");
                Collectable2.SetActive(false);
                wrenchCollected = true;
               wrenchUISprite.SetActive(false);
                Destroy(other.gameObject);
                checkForCompletion();
            }

            if (other.gameObject.name == "Gyro")
            {
                audioScript.PlayAudioClip("Collect");
                Collectable3.SetActive(false);
                GyroUISprite.SetActive(false);
                gyroCollected = true;
                Destroy(other.gameObject);
                checkForCompletion();
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
        if (other.gameObject.tag == "oxyPoint1")
        {
            checkpoint = new Vector3(7.88f, 44.61f, -138.75f);
        }
        if (other.gameObject.tag == "oxyPoint2")
        {
            checkpoint = new Vector3(0, 0, 0);
        }
        if (other.gameObject.tag == "oxyPoint3")
        {
            checkpoint = new Vector3(0, 0, 0);
        }
        if (other.gameObject.tag == "oxyPoint4")
        {
            checkpoint = new Vector3(0, 0, 0);
        }
        if (other.gameObject.tag == "oxyPoint5")
        {
            checkpoint = new Vector3(0, 0, 0);
        }
        if (other.gameObject.tag == "oxyPoint6")
        {
            checkpoint = new Vector3(0, 0, 0);
        }
        if (other.gameObject.tag == "oxyPoint7")
        {
            checkpoint = new Vector3(0,0,0);
        }

    }

    // Add this method to respawn the player at the last checkpoint
    public void RespawnPlayer()
    {
        /*
        float playerPosX = PlayerPrefs.GetFloat("PlayerPosX");
        float playerPosY = PlayerPrefs.GetFloat("PlayerPosY");
        float playerPosZ = PlayerPrefs.GetFloat("PlayerPosZ");

        Vector3 respawnPosition = new Vector3(playerPosX, playerPosY, playerPosZ);

        transform.position = respawnPosition;
        */
        Debug.Log("respawn");
        transform.position = checkpoint;
        oxygenLevel.currentOxygenLevel = oxygenLevel.maxOxygenLevel;
        doomPanel.SetActive(false);
        oxyDeathPanel.SetActive(false);
    }

    public void checkForCompletion()
    {
        if(chipCollected && wrenchCollected && gyroCollected)
        {
            allItemsCollected = true;

        }
        


    }
}
