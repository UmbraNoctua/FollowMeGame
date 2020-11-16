using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class walkdirt_audio : MonoBehaviour
{
    public AudioClip firstAudioClip;
    public AudioClip secondAudioClip;
    public AudioClip thirdAudioClip;
    public AudioClip fourthAudioClip;
    public AudioClip fifthAudioClip;
    public AudioClip sixthAudioClip;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnCollisionEnter()
    {
        audioSource.PlayOneShot(firstAudioClip, 0.3f);
        audioSource.PlayOneShot(secondAudioClip, 0.3f);
        audioSource.PlayOneShot(thirdAudioClip, 0.3f);
        audioSource.PlayOneShot(fourthAudioClip, 0.3f);
        audioSource.PlayOneShot(fifthAudioClip, 0.3f);
        audioSource.PlayOneShot(sixthAudioClip, 0.3f);
        
    }
}
