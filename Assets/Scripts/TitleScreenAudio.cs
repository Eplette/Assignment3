using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenAudio : MonoBehaviour
{

    public AudioClip introMusic;
    public AudioSource audioSource; // <-- need an audiosource to play the clip

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = introMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}
