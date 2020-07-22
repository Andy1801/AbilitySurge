using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO Make jumping a counter

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject dashEffect;
    public float playerSpeed;
    public float jumpForce;

    private Player player;
    private Grounded grounded;
    private Timer timer;

    private float moveInput;

    public float jumpTime;

    private bool isJumping;
    private int jumpsLeft;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        grounded = player.GetComponentInChildren<Grounded>();
        timer = new Timer(jumpTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * playerSpeed, rb.velocity.y);
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        Jump();
    }

    void Jump()
    {
        if (grounded.getIsGrounded() == true && Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            timer.StartTimer();
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (!timer.getTimerStatus() && isJumping)
                rb.velocity = Vector2.up * jumpForce;
            else
                isJumping = false;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }
    }
}
