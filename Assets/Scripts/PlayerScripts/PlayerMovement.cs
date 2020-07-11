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

    private bool isGrounded = true;

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
        Vector2 movement = new Vector2(moveHorizontal, 0);

        transform.Translate(movement * Time.deltaTime * playerSpeed);
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
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }

    public bool getIsGrounded()
    {
        return isGrounded;
    }
}
