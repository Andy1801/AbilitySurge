using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTransformMovement : MonoBehaviour
{
    public Vector2 movement;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        move();
    }

    //This type of movement is frame dependent because we are moving objects per transform.
    private void move()
    {
        transform.Translate(movement * speed * Time.deltaTime);
    }

}
