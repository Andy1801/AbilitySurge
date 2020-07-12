using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : IAbilities
{
    private bool dashing;

    private float timer;
    private float dashTime = 0.15f;

    private Rigidbody2D rigidbody2D;
    private PlayerMovement playerMovement;
    private Renderer playerRenderer;

    public bool actionCondition(GameObject player)
    {
        playerRenderer = player.GetComponent<MeshRenderer>();
        playerRenderer.material.SetColor("_Color", Color.yellow);

        if (Input.GetKeyDown(KeyCode.Space) && !dashing)
        {
            dashing = true;
            return dashing;
        }
        return false;
    }

    public void action(GameObject player)
    {
        rigidbody2D = player.GetComponent<Rigidbody2D>();
        playerMovement = player.GetComponent<PlayerMovement>();

        rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        playerMovement.playerSpeed = playerMovement.playerSpeed + 40;
    }

    public void actionCleanUp(GameObject player, bool strictCleanup)
    {
        if (dashing)
        {
            timer += Time.deltaTime;
            if (timer > dashTime || strictCleanup)
            {
                rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                playerMovement.playerSpeed = playerMovement.playerSpeed - 40;
                timer = 0f;
                dashing = false;
            }
        }
    }
}
