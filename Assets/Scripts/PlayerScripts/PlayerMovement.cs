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

    private bool isGrounded = false;

    Rigidbody2D rigidbody2d;

    void Start()
    {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");


        Jump();
        rigidbody2d.velocity = new Vector2(moveHorizontal * playerSpeed, rigidbody2d.velocity.y);
    }

    //Checks if the player is on the ground whenever it has a collision
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            Debug.Log("Grounded");
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            PlatformMovement platformMovement = other.gameObject.GetComponent<PlatformMovement>();

            if (platformMovement != null)
                transform.Translate(platformMovement.movementOffset * Time.deltaTime);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
            Debug.Log("Flying");
        }
    }

    //Method that handles applying the jumping force
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
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

    public bool getIsGrounded()
    {
        return isGrounded;
    }
}
