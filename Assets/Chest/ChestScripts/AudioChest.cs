using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChest : MonoBehaviour
{
    public AudioClip SoundToPlay;
    public float Volume;
    AudioSource audio1;
    public bool alreadyPlayed = false;

    void Start()
    {
        audio1 = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!alreadyPlayed)
        {
            audio1.PlayOneShot(SoundToPlay, Volume);
            alreadyPlayed = true;
           // /ScoreChest.scoreValue += 1;
        }
    }
}
