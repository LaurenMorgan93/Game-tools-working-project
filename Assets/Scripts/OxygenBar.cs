using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OxygenBar : MonoBehaviour
{
    private Slider oxygenSlider; 
    private GameObject player;
    private float playerYPosition; // Store the player's Y position here
    private float maxOxygenLevel; 
    private float currentOxygenLevel;
    public Color maxColor = Color.green; // Color when the slider is at its maximum
    public Color minColor = Color.red; // Color when the slider is below 10%
    public float decreaseRate; // Rate at which maxOxygenLevel decreases
    public float increaseRate;
    public float oxyDepletionHeight; // Height above which oxygen starts decreasing
    public Image barImage; 
    public GameObject oxygenWarningImage;
    public TextMeshProUGUI heightText;
    public Animator OxyBarAnim;
    public Animator HelmetAnim;
    public GameObject DoomPanel;
    public GameObject OxyDeathPanel;
    public bool HelmetWorn = false;
    public bool InSafeZone;


    void Start()
    {
        // Initialize the colors and maxOxygenLevel
        Time.timeScale = 1f;
        barImage.color = maxColor;
        oxygenSlider = GetComponent<Slider>();
        maxOxygenLevel = oxygenSlider.maxValue;
        currentOxygenLevel = oxygenSlider.maxValue;
        player = GameObject.FindWithTag("Player");
        oxygenWarningImage.SetActive(false);
        DoomPanel.SetActive(false);
        OxyDeathPanel.SetActive(false);
    }

    void Update()
    {
        manageHeightUI();
        drainOxygen();
        restoreOxygenNaturally();
        manageOxygenUI();
        animateHelmetOFF();
        animateHelmetON();
        
    }

    public void manageOxygenUI()
    {
        // Check the current value of the slider
        float sliderValue = oxygenSlider.value;

        // Calculate the color based on the oxygen level
        barImage.color = Color.Lerp(minColor, maxColor, sliderValue / maxOxygenLevel);

        // Activate the warning image when currentOxygenLevel is less than or equal to half of maxOxygenLevel
        if (currentOxygenLevel <= maxOxygenLevel * 0.5f && currentOxygenLevel >= maxOxygenLevel * 0.25f)
        {
            oxygenWarningImage.SetActive(true);
            OxyBarAnim.SetTrigger("Half Oxy");
        }

        else if (currentOxygenLevel <= maxOxygenLevel * 0.25f)
        {
            oxygenWarningImage.SetActive(true);
            OxyBarAnim.SetTrigger("Low Oxy");

        }
        else
        {
            oxygenWarningImage.SetActive(false);
            OxyBarAnim.SetTrigger("Restored Oxy");
        }

        if(currentOxygenLevel <= 0)
        {
            OxyDeathPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }


    public void manageHeightUI()
    {
        // Get the player's position on the Y-axis
        playerYPosition = player.transform.position.y;

        // Update TextMeshPro text box with the rounded-up Y position
        heightText.text =  Mathf.Ceil(playerYPosition).ToString() + " M";

        if(playerYPosition <= -100)
        {
            DoomPanel.SetActive(true);
        }

    }

    public void drainOxygen()
    {
        // Reduce currentOxygenLevel gradually when the player is above a certain height
        if (playerYPosition > oxyDepletionHeight)
        {

            currentOxygenLevel -= decreaseRate * Time.deltaTime;
            // Ensure currentOxygenLevel does not go below 0
            currentOxygenLevel = Mathf.Max(currentOxygenLevel, 0f);
        }
        // Update the slider's value based on the current maxOxygenLevel
        oxygenSlider.value = currentOxygenLevel;
    }

    public void restoreOxygenNaturally()
    {
        if(playerYPosition < oxyDepletionHeight && currentOxygenLevel < maxOxygenLevel)
        {
            currentOxygenLevel += decreaseRate * Time.deltaTime;
            oxygenSlider.value = currentOxygenLevel;
        }
    }

    public void RestoreOxyAtCheckpoint()
    {
        if(currentOxygenLevel < maxOxygenLevel && playerYPosition > oxyDepletionHeight)
        {
            currentOxygenLevel += increaseRate * Time.deltaTime;
            oxygenSlider.value = currentOxygenLevel;
        }
    }

    public void animateHelmetON(){
        if(playerYPosition >= oxyDepletionHeight && !HelmetWorn && !InSafeZone)
        {
             HelmetAnim.SetTrigger("Worn");
             HelmetWorn = true;
        }

        
    }

    public void animateHelmetOFF(){
        if(playerYPosition < oxyDepletionHeight && HelmetWorn && InSafeZone)
        {
            HelmetAnim.SetTrigger("Not Worn");
            HelmetWorn = false;
        }
    }

    public void MineOxygenDecrease(int MineValue)
    {
        currentOxygenLevel -= MineValue;
        oxygenSlider.value = currentOxygenLevel;


    }




}
