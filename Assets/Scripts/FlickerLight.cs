using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public Light light;
    public AudioSource clip;

    public float minTime, maxTime, timer;
    void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        PiscaPisca();
    }

    void PiscaPisca()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0)
        {
            light.enabled = !light.enabled;
            timer = Random.Range(minTime, maxTime);
        }
    }
}
