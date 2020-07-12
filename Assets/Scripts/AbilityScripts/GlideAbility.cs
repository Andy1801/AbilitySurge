using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlideAbility : IAbilities
{
    private const float X = 0f;
    private float originalGravity = 0f;

    private Renderer playerRenderer;
    private PlayerMovement playerMovement;
    private Rigidbody2D rigidbody2D;

    public bool actionCondition(GameObject player)
    {
        playerRenderer = player.GetComponent<MeshRenderer>();
        playerMovement = player.GetComponent<PlayerMovement>();
        rigidbody2D = player.GetComponent<Rigidbody2D>();

        playerRenderer.material.SetColor("_Color", Color.blue);

        if (originalGravity == 0)
            originalGravity = rigidbody2D.gravityScale;

        return Input.GetKey(KeyCode.Space) && !playerMovement.getIsGrounded();
    }

    public void action(GameObject player)
    {
        float downwardSpeed = -2f;
        float glidingGravity = 0f;

        Vector2 downwardMovement = new Vector2(rigidbody2D.velocity.x, downwardSpeed);

        rigidbody2D.gravityScale = glidingGravity;
        rigidbody2D.velocity = downwardMovement;
    }

    public void actionCleanUp(GameObject player, bool strictCleanup)
    {
        rigidbody2D.gravityScale = originalGravity;
    }

}
