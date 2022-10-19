using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSound : MonoBehaviour
{
	public float pitch, volume;

	public float min, max, ram, value, side;

	public float pitchMin, pitchMax;

	private AudioSource SomPorra;
    private void Awake()
    {
		SomPorra = GetComponent<AudioSource>();

	}

    private void Start()
    {
		ram = Mathf.Ceil(Random.Range(min, max));
		pitch = Mathf.Ceil(Random.Range(pitchMin, pitchMax));

	}

    internal void Play_Audio_Source()
	{
		//Debug.Log("AudioSourcePlayer: Play_Audio_Source");

		//get the audio source part of this transform and play it
		//this assumes there is only one audio source attached to this transform
		var audio_source = this.transform.GetComponent<AudioSource>();
		if (audio_source)
		{
			audio_source.pitch = pitch;
			audio_source.volume = volume;
			audio_source.Play();
		}
	}


	internal void Stop_Audio_Source()
	{
		var audio_source = this.transform.GetComponent<AudioSource>();
		if (audio_source)
		{
			audio_source.Stop();
		}
	}

    private void Update()
    {
		PlayAtRandom();
    }

	void PlayAtRandom()
    {
		if (ram <= value)
        {
			Debug.Log("PSSSSST");
			if(ram % 2 == 0)
            {
				SomPorra.panStereo = 1;
				SomPorra.pitch = pitch;
				SomPorra.volume = volume;
				SomPorra.Play();
				ram = Mathf.Ceil(Random.Range(min, max));
				pitch = Mathf.Ceil(Random.Range(pitchMin, pitchMax));
			} else
            {
				SomPorra.panStereo = -1;
				SomPorra.pitch = pitch;
				SomPorra.volume = volume;
				SomPorra.Play();
				ram = Mathf.Ceil(Random.Range(min, max));
				pitch = Mathf.Ceil(Random.Range(pitchMin, pitchMax));

			}
			
		} else
        {
			ram = Mathf.Ceil(Random.Range(min, max));
			Debug.Log("Nada");
        }

	}
}
