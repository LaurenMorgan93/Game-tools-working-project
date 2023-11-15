using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ThrustController : MonoBehaviour
{
    public Rigidbody rb;

    public bool enableThrust = true;
    public KeyCode thrustKey = KeyCode.LeftShift;
    public float thrusterForce;
    public float maxThrustTime = 3.0f; // Maximum thrusting time in seconds
    public float thrustCooldown = 2.0f; // Cooldown time after thrusting in seconds

    public Slider thrustSlider; // Drag and drop the UI Slider from the hierarchy here

    private bool isThrusting;
    private float thrustStartTime;
    private float thrustCooldownTimer;

    private void Awake()
    {
        if (enableThrust)
        {
            isThrusting = false;
            thrustCooldownTimer = 0; // Initialize to 0 to allow thrusting at the start
            UpdateThrustSlider();
        }
    }

    private void Update()
    {
        if (enableThrust)
        {
            if (isThrusting)
            {
                if (Time.time - thrustStartTime >= maxThrustTime)
                {
                    isThrusting = false;
                    thrustCooldownTimer = thrustCooldown;
                }
            }
            else
            {
                if (Input.GetKey(thrustKey) && thrustCooldownTimer <= 0 && thrustSlider.value > 0)
                {
                    isThrusting = true;
                    thrustStartTime = Time.time;
                }
            }

            if (thrustCooldownTimer > 0)
            {
                thrustCooldownTimer -= Time.deltaTime;
                UpdateThrustSlider();
            }

            if (isThrusting)
            {
                // Apply a continuous force in the forward and upward directions
                Vector3 thrustDirection = transform.forward + Vector3.up;
                rb.AddForce(thrustDirection.normalized * thrusterForce);
            }
        }

        UpdateThrustSlider();
    }

    private void UpdateThrustSlider()
    {
        if (thrustSlider != null)
        {
            float thrustProgress = isThrusting
                ? Mathf.Clamp01((Time.time - thrustStartTime) / maxThrustTime)
                : 1 - Mathf.Clamp01(thrustCooldownTimer / thrustCooldown);

            thrustSlider.value = thrustProgress;
        }
    }
}
