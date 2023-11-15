using UnityEngine;

public class ParkourSlide : MonoBehaviour
{
    [Header("Sliding Parameters")]
    public float slideSpeed = 5f; // Adjust the sliding speed in the Unity Inspector
    public LayerMask prismLayer; // Layer to identify prism-shaped objects

    private bool isSliding = false;
    private Vector3 slideDirection;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (isSliding)
        {
            // Apply a constant force to simulate sliding
            rb.AddForce(slideDirection * slideSpeed, ForceMode.VelocityChange);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the player collided with a prism object
        if (collision.gameObject.CompareTag("PrismObject") && !isSliding)
        {
            // Calculate the slide direction based on the normal of the collision
            slideDirection = -collision.contacts[0].normal;
            slideDirection.y = 0f; // Ensure no vertical movement

            // Start sliding
            isSliding = true;

            // Disable gravity while sliding to prevent sticking to the object
            rb.useGravity = false;

            // Debug log to indicate sliding initiation
            Debug.Log("Player started sliding on a prism object.");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Check if the player stopped colliding with the prism object
        if (collision.gameObject.CompareTag("PrismObject") && isSliding)
        {
            // Stop sliding
            isSliding = false;

            // Re-enable gravity when sliding stops
            rb.useGravity = true;

            // Debug log to indicate sliding termination
            Debug.Log("Player stopped sliding on a prism object.");
        }
    }
}

