using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlideAbility : IAbilites
{
    const float gravityBuffer = 0.5f;

    public bool actionCondition(GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        
        return playerMovement.getIsGrounded();
    }

    public void action(GameObject player)
    {
        Rigidbody2D rigidbody2D = player.GetComponent<Rigidbody2D>();

        rigidbody2D.gravityScale *= gravityBuffer;
    }
 
}
