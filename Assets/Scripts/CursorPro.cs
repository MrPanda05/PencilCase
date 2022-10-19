using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPro : MonoBehaviour
{
    public Texture2D crossHair;

    Vector2 cursorOff;

    private void Start()
    {
        cursorOff = new Vector2(crossHair.width / 2, crossHair.height / 2);
        Cursor.lockState = CursorLockMode.Locked;

        Cursor.SetCursor(crossHair, cursorOff, CursorMode.Auto);
    }
}
