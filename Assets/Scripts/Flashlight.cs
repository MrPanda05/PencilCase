using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlight;

    private bool inputs, isLight;

    private void GetKey()
    {
        inputs = Input.GetKeyDown(KeyCode.F);
        if (inputs)
        {
            if (!isLight)
            {
                isLight= true;
                flashlight.enabled = true;
            }
            else
            {
                isLight = false;
                flashlight.enabled = false;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetKey();

    }
}
