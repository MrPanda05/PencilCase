using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float mvSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;

    bool grounded;

    public Transform orientation;

    float hInput, vInput;

    Vector3 moveDire;

    Rigidbody rig;

    //limit vectors

    Vector3 flatVel, limitedVel;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.freezeRotation = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        InputGetter();
        SpeedControl();

        if (grounded)
        {
            rig.drag = groundDrag;
        } else
        {
            rig.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        moveDire = orientation.forward * vInput + orientation.right * hInput;

        rig.AddForce(moveDire.normalized * mvSpeed * 10f, ForceMode.Force);
    }

    private void InputGetter()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
    }

    private void SpeedControl()
    {
        flatVel = new Vector3(rig.velocity.x, 0f, rig.velocity.y);

        if(flatVel.magnitude > mvSpeed)
        {
            limitedVel = flatVel.normalized * mvSpeed;
            rig.velocity = new Vector3(limitedVel.x, rig.velocity.y, limitedVel.z);
        }
    }
}
