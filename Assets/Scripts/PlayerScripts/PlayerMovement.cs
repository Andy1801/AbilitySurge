using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO Fix jumping by applying physics forces 
//TODO Fix side collision when jumping
//TODO Add jump counter (???) 

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public float jumpSpeed;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 1f;

    Rigidbody2D rigidbody2d;
    Grounded grounded;

    void Start()
    {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        grounded = gameObject.GetComponentInChildren<Grounded>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");


        Jump();
        rigidbody2d.velocity = new Vector2(moveHorizontal * playerSpeed, rigidbody2d.velocity.y);
    }

    //Method that handles applying the jumping force
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && grounded.getIsGrounded())
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, 0f);
            rigidbody2d.velocity += Vector2.up * jumpSpeed;
        }
        if (rigidbody2d.velocity.y < 0)
        {
            rigidbody2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rigidbody2d.velocity.y > 0 && !Input.GetKey(KeyCode.W))
        {
            rigidbody2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
