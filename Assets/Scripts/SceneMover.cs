using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{


    public string destinationSceneName; // Name of the destination scene

    public void LoadScene()
    {
        SceneManager.LoadScene(destinationSceneName);
    }

}
