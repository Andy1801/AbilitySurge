using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidBodyMovement : MonoBehaviour
{
    public Vector2 movement;
    public float speed;

    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        if (!movement.Equals(Vector2.zero))
            rigidbody.MovePosition((Vector2)rigidbody.position + (movement * speed));
    }
}
