using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Change the grounded class logic to use ray casting
//TODO: Move platforming moving logic to the platform movement class as to decouple the code more
public class Grounded : MonoBehaviour
{

    private bool isGrounded;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
        playerTransform = GetComponentInParent<Transform>();
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

    public bool getIsGrounded()
    {
        return isGrounded;
    }
}
