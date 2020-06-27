using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody myRb;

    public Vector2 MovingInput
    {
        get
        {
            return movingInput;
        }

        set
        {
            //movingInput = (value == Vector2.zero) ? Vector2.zero : Vector2.Lerp(movingInput, value, 0.2f).normalized;
            if (/*InputManager.ActualDevice == Device.PCMouseKeyboard && */value != Vector2.zero)
            {
                movingInput = Vector2.Lerp(movingInput, value, 0.2f).normalized;
            }
            else
                movingInput = value;
        }
    }

    static float playerSpeed = 10.0f;
    public float gravity = 9.8f;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    public Vector2 movingInput;

    private void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovingInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {

        //        player.transform.LookAt(player.transform.position + movePlayer);

        if (MovingInput != Vector2.zero) transform.forward = new Vector3(MovingInput.x, transform.forward.y, MovingInput.y);
        myRb.velocity = new Vector3(MovingInput.x, myRb.velocity.y, MovingInput.y) * playerSpeed;
        
        

        //Debug.Log(player.velocity.magnitude);        

        //movePlayer = movePlayer * playerSpeed;
    }
    
    
}
