using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlideAbility : IAbilities
{
    private const float lerpTime = 0.2f;
    private float originalGravity = 0f;

    private Renderer playerRenderer;
    private PlayerMovement playerMovement;
    private Rigidbody2D rigidbody2D;
    private Grounded grounded;

    public bool actionCondition(GameObject player)
    {
        rigidbody2D = player.GetComponent<Rigidbody2D>();
        grounded = player.GetComponentInChildren<Grounded>();

        if (originalGravity == 0)
            originalGravity = rigidbody2D.gravityScale;

        return Input.GetKey(KeyCode.Space) && !grounded.getIsGrounded();
    }

    public void action(GameObject player)
    {
        float downwardSpeed = -2f;
        float glidingGravity = 0f;

        Vector2 downwardMovement = new Vector2(rigidbody2D.velocity.x, downwardSpeed);


        rigidbody2D.gravityScale = glidingGravity;
        rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, downwardMovement, lerpTime);
    }

    public void actionCleanUp(GameObject player, bool strictCleanup)
    {
        rigidbody2D.gravityScale = originalGravity;
    }

}
