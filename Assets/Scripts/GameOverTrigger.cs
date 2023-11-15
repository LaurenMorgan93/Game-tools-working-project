using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            reload();
        }
    }
 
 public void OnTriggerEnter (Collider other)
 {
    if(other.gameObject.tag == ("Player"))
    {
        Debug.Log("Collided with Player");
        SceneManager.LoadScene("LaurenScene");
    }
 }


 public void reload(){
    SceneManager.LoadScene("LaurenScene");
 }


}
