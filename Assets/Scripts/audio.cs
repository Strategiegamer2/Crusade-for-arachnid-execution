using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class audio : MonoBehaviour
{
    public AudioClip otherClip;
    AudioSource audioChange;
    int nummer;

    private void Start()
    {
        audioChange = GetComponent<AudioSource>();
        audioChange.Play();
        nummer = 0;
    }


    private void Update()
    {
        if (audioChange.isPlaying == false && nummer == 0)
        {
            nummer++;
            audioChange.clip = otherClip;
            audioChange.Play();
        }
    }
}