using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO Platform studdering when the player gets on it
//TODO Move logic from grounded to here that involves moving the player when atop the platfom
public class PlatformMovement : MonoBehaviour {
    public float movementTimer;
    public Vector3 movementOffset;

    private Timer timer;

    void Start () {
        timer = new Timer (movementTimer);
        timer.StartTimer ();
    }

    void Update () {
        if (timer.getTimerStatus ())
            movementOffset = reversalMovementAndTimer ();
        else
            transform.position += (movementOffset * Time.deltaTime);
    }

    void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Ground")
            movementOffset = reversalMovementAndTimer ();
    }

    void OnCollisionStay2D (Collision2D other) {
        Transform transform = other.gameObject.GetComponent<Transform> ();
        transform.Translate (movementOffset * Time.deltaTime, Space.World);
    }

    Vector3 reversalMovementAndTimer () {
        timer.StartTimer ();
        return movementOffset *= -1;
    }
}