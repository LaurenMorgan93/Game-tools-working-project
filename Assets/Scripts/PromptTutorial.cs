using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PromptTutorial : MonoBehaviour
{

    public GameObject jumpText;
    // Start is called before the first frame update
    void Start()
    {
        jumpText.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            jumpText.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            jumpText.SetActive(false);
        }
    }
}
