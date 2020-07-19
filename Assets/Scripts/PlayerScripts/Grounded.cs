using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Change the grounded class logic to use ray casting
//TODO: Move platforming moving logic to the platform movement class as to decouple the code more
public class Grounded : MonoBehaviour
{

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            Debug.Log("Grounded");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
            Debug.Log("Flying");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            PlatformMovement platformMovement = other.gameObject.GetComponent<PlatformMovement>();

            if (platformMovement != null)
                transform.Translate(platformMovement.movementOffset * Time.deltaTime);
        }
    }

    public bool getIsGrounded()
    {
        return isGrounded;
    }
}
