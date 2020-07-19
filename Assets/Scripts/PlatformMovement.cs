using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO Platform studdering when the player gets on it
//TODO Move logic from grounded to here that involves moving the player when atop the platfom
public class PlatformMovement : MonoBehaviour
{
    private float timer;
    public float movementTimer;

    public Vector3 movementOffset;

    void Start()
    {
        timer = 0f;
    }

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
