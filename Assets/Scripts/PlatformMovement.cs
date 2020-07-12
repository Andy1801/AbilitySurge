using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO Platform studdering when the player gets on it
public class PlatformMovement : MonoBehaviour
{
    private float timer;
    public float movementTimer;

    public Vector3 movementOffset;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= movementTimer)
            movementOffset = reversalMovementAndTimer();
        else
            transform.position += (movementOffset * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
            movementOffset = reversalMovementAndTimer();
    }

    Vector3 reversalMovementAndTimer()
    {
        timer = 0f;
        return movementOffset *= -1;
    }
}
