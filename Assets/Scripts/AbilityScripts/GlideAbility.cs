using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlideAbility : IAbilities
{
    private const float lerpTime = 0.2f;
    private float originalGravity = 0f;

    private Color abilityColor = Color.black;
    private SpriteRenderer playerSpriteRenderer;
    private PlayerMovement playerMovement;
    private Rigidbody2D rigidbody2D;
    private Grounded grounded;

    public bool actionCondition(GameObject player)
    {
        rigidbody2D = player.GetComponent<Rigidbody2D>();
        grounded = player.GetComponentInChildren<Grounded>();
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();

        if (originalGravity == 0)
            originalGravity = rigidbody2D.gravityScale;

        playerSpriteRenderer.color = abilityColor;

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
