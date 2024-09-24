using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip introMusic;
    public AudioClip normalStateMusic;

    // v need an audiosource to play the clips 
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(introMusic);
        StartCoroutine(playNormalState(introMusic.length));
    }

    IEnumerator playNormalState(float introLength) { // <-- need to do it this way because of PlayOneShot (not actually setting the audioSource clip so can't do audioSource.clip.length later)
        yield return new WaitForSeconds(introLength); // <-- makes it wait for the intro music to finish before continuing
        audioSource.PlayOneShot(normalStateMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
