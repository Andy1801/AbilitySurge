using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlideAbility : IAbilites
{
    const float glidingGravity = 0.5f;

    private float originalGravity = 0f;

    public bool actionCondition(GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        Rigidbody2D rigidbody2D = player.GetComponent<Rigidbody2D>();

        if(originalGravity == 0)
            originalGravity = rigidbody2D.gravityScale;

        return !playerMovement.getIsGrounded();
    }

    public void action(GameObject player)
    {
        Rigidbody2D rigidbody2D = player.GetComponent<Rigidbody2D>();

        rigidbody2D.gravityScale = glidingGravity;
    }

    public void actionCleanUp(GameObject player)
    {
        Rigidbody2D rigidbody2D = player.GetComponent<Rigidbody2D>();

        rigidbody2D.gravityScale = originalGravity;
    }
 
}
