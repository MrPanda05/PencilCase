using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSound : MonoBehaviour
{
    public AudioSource clip;

    public float clipVolume;

    private BoxCollider box;

    public GameObject toBeDestroyed, toBeActived;

    bool hasPlayed;

    private void Awake()
    {
        box = GetComponent<BoxCollider>();
    }


    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.CompareTag("Player"))
            {
            if (!hasPlayed)
            {
                hasPlayed = true;
                clip.Play();
                toBeDestroyed.SetActive(false);
                toBeActived.SetActive(true);
            }
                
            }
    }
}
