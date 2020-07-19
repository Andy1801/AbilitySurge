using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Think about momentum ALOT!!!!
//TODO: Think about making the jump less floaty so that the double feels more rewarding to have
//TODO: Change double jump so that it modifies a counter in the player character to give them a double jump and remove the current logic
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
        playerRenderer = player.GetComponent<MeshRenderer>();
        rigidbody2d = player.GetComponent<Rigidbody2D>();
        playerMovement = player.GetComponent<PlayerMovement>();
        grounded = player.GetComponentInChildren<Grounded>();
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
            rigidbody2d.velocity += Vector2.up * playerMovement.jumpSpeed;
            jumping = false;
        }

        if (rigidbody2d.velocity.y < 0)
        {
            rigidbody2d.velocity += Vector2.up * Physics2D.gravity.y * (playerMovement.fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rigidbody2d.velocity.y > 0 && !Input.GetKey(KeyCode.W))
        {
            rigidbody2d.velocity += Vector2.up * Physics2D.gravity.y * (playerMovement.lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    //Clean up for the action performed
    public void actionCleanUp(GameObject player, bool strictCleanup)
    {

    }
}
