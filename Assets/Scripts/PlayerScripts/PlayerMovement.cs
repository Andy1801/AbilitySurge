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

    private float moveInput;

    private float jumpTimeCounter;
    public float jumpTime;

    private bool isJumping;
    private int jumpsLeft;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        grounded = player.GetComponentInChildren<Grounded>();
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
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (jumpTimeCounter > 0 && isJumping == true)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }
    }
}
