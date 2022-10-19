using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundGenerec : MonoBehaviour
{
    public string nameTag;

    private BoxCollider box;

    public bool hasPlayed;

    public AudioSource clip;

    private void Awake()
    {
        box = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed)
        {
            if (other.gameObject.CompareTag(nameTag))
            {
                clip.Play();
                hasPlayed = true;

            }
        }
    }

}
