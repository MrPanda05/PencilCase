using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundBut : MonoBehaviour
{
    public AudioSource source;

    public void PlayAudioGamer()
    {
        source.Play();
    }
}
