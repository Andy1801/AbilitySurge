using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpAbility : IAbilities
{
    private PlayerMovement playerMovement;
    private Renderer playerRenderer;
    private Rigidbody2D rigidbody2d;
    private bool canJump;
    private Grounded grounded;

    // Condition for performing the action
    public bool actionCondition(GameObject player)
    {
        playerRenderer = player.GetComponent<MeshRenderer>();
        rigidbody2d = player.GetComponent<Rigidbody2D>();
        playerMovement = player.GetComponent<PlayerMovement>();
        grounded = player.GetComponentInChildren<Grounded>();
        playerRenderer.material.SetColor("_Color", Color.green);

        if (Input.GetKeyDown(KeyCode.W) && canJump)
        {
            canJump = true;
        }
        else if (grounded.getIsGrounded())
        {
            canJump = true;
        }
        return canJump;
    }

    // Action being performed 
    public void action(GameObject player)
    {
        rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, 0f);
        rigidbody2d.velocity += Vector2.up * playerMovement.jumpSpeed;
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
