using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private float sensX, sensY;

    public Transform orientation;

    float xRotation, yRotation, mouseX, mouseY;

    //public Texture2D crossHair;

    //Vector2 cursorOff;

    private void Start()
    {
        //cursorOff = new Vector2(crossHair.width / 2, crossHair.height / 2);
        //Cursor.lockState = CursorLockMode.Locked;

        //Cursor.SetCursor(crossHair, cursorOff, CursorMode.Auto);
        Cursor.visible = false;
    }

    private void Update()
    {
        mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
