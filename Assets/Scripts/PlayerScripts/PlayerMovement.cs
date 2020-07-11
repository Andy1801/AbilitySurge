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

    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");


        Jump();
        rigidbody.velocity = new Vector2(moveHorizontal * playerSpeed, rigidbody.velocity.y);
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
        if(other.gameObject.tag == "Ground")
        {
            PlatformMovement platformMovement = other.gameObject.GetComponent<PlatformMovement>();

            if(platformMovement != null)
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

    //Method that handles apllying the jumping force
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
            rigidbody.velocity += Vector2.up * jumpSpeed;
        }
        if (rigidbody.velocity.y < 0)
        {
            rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rigidbody.velocity.y > 0 && !Input.GetKey(KeyCode.W))
        {
            rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    public bool getIsGrounded()
    {
        return isGrounded;
    }
}
