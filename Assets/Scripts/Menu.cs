using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public GameObject InfoPanel;
    public bool InfoOpen = true;

    public void Update(){
        closeMenuPanel();

    }
  

    public void closeMenuPanel(){

        if(InfoOpen){
            if(Input.GetKeyDown(KeyCode.P)){

                InfoPanel.SetActive(false);
                InfoOpen = false;

            }
        }

        else if(!InfoOpen){
            if(Input.GetKeyDown(KeyCode.P)){
                InfoPanel.SetActive(true);
                InfoOpen = true;
            }
        }
    }
}
