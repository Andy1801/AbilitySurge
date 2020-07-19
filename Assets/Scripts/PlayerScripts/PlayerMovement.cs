using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO Fix side collision when jumping
//TODO Add jump counter (???) 
//TODO Look into how update, fixedUpdate, and lateUpdate actually works and how it relates to movement. Should we be using update to move the character using physic forces
//TODO Think about what type movement would be better. Physic forces movement or transformer movement.
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
