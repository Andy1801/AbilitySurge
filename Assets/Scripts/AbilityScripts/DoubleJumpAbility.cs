using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpAbility : IAbilities
{
    private PlayerMovement playerMovement;
    private Renderer playerRenderer;
    private Rigidbody2D rigidbody2d;
    private bool canJump = true;
    private bool jumping;
    private Grounded grounded;

    // Condition for performing the action
    public bool actionCondition(GameObject player)
    {
        rigidbody2d = player.GetComponent<Rigidbody2D>();
        playerMovement = player.GetComponent<PlayerMovement>();
        grounded = player.GetComponentInChildren<Grounded>();
        playerRenderer = player.GetComponent<MeshRenderer>();
        playerRenderer.material.SetColor("_Color", Color.green);

        if (Input.GetKeyDown(KeyCode.W) && !grounded.getIsGrounded() && canJump)
        {
            jumping = true;
            canJump = false;
            return jumping;
        }
        else if (grounded.getIsGrounded())
        {
            canJump = true;
        }
        return jumping;
    }

    // Action being performed 
    public void action(GameObject player)
    {

        if (jumping)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, 0f);
            rigidbody2d.velocity += Vector2.up * playerMovement.jumpForce * 2;
            jumping = false;
        }

    }

    //Clean up for the action performed
    public void actionCleanUp(GameObject player, bool strictCleanup)
    {

    }
}
