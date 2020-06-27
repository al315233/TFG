using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2dController : MonoBehaviour
{
    public static Player2dController Instance; 

    const float PLAYER_SPEED = 15f;


    Vector2 playerInput;
    Rigidbody2D myRb;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInput = Vector2.up * Input.GetAxis("Vertical") + Vector2.right * Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        myRb.velocity = playerInput * PLAYER_SPEED;
    }
}
