using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip gunshotSFX;
    public AudioClip deathSFX;
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGunshotSFX(float volume)
    {
        audioSource1.PlayOneShot(gunshotSFX, volume);
    }

    public void PlayDeathSFX()
    {
        audioSource2.PlayOneShot(deathSFX);
    }


}
