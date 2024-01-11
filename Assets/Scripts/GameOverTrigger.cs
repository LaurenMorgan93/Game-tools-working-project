using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    public PlayerController controller;

    public void Start()
    {
        //controller = GetComponent<PlayerController>();
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            controller.RespawnPlayer();
        }
    }
 
 public void OnTriggerEnter (Collider other)
 {
    if(other.gameObject.tag == ("Player"))
    {
        Debug.Log("Collided with Player");
        controller.RespawnPlayer();
    }
 }


 public void reload(){
    SceneManager.LoadScene("LaurenScene");
 }


}
