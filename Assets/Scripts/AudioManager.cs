using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioComponent;

    void Start()
    {
        audioComponent = GetComponent<AudioSource>();
    }

    public void PlayAudioClip(string clipName)
    {
        // Load the audio clip from the Resources folder based on the provided clip name
        AudioClip audioClip = Resources.Load<AudioClip>(clipName);

        if (audioClip != null)
        {
            audioComponent.clip = audioClip; // Use audioComponent instead of undefined audioSource
            audioComponent.Play();
        }
        else
        {
            Debug.LogError("Audio clip not found: " + clipName);
        }
    }
}
