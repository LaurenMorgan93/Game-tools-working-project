using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public float rotationSpeed = 10.0f; // Adjust the rotation speed as needed

    void Update()
    {
        // Find all GameObjects with the "Planet" tag in the scene
        GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");

        // Rotate each of the found planets slowly and continuously
        foreach (GameObject planet in planets)
        {
            planet.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}