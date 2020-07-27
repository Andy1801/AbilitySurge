using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: When the player turns tiny they are falling. They should be on the ground at the moment that they turn tiny as to remove a jump
public class TinyAbility : IAbilities
{
    private const float X = 0.5f, Y = 0.5f, Z = 1f;

    Vector3 originalScale = Vector3.zero;
    Vector3 tinyScale = new Vector3(X, Y, Z);

    float originalGravity = 0f;
    float tinyGravity = 3f;

    private Renderer playerRenderer;
    private Transform transform;
    private Rigidbody2D rigidbody2D;

    private bool notTiny = true;

    public bool actionCondition(GameObject player)
    {
        playerRenderer = player.GetComponent<MeshRenderer>();
        playerRenderer.material.SetColor("_Color", Color.white);

        transform = player.GetComponent<Transform>();
        rigidbody2D = player.GetComponent<Rigidbody2D>();

        if (originalScale == Vector3.zero)
        {
            originalScale = transform.localScale;
            originalGravity = rigidbody2D.gravityScale;
        }

        return Input.GetKey(KeyCode.Space);
    }

    public void action(GameObject player)
    {

        rigidbody2D.gravityScale = tinyGravity;
        transform.localScale = tinyScale;

        if (notTiny)
        {
            float verticalSizeChange = playerRenderer.bounds.extents.y;
            transform.position = new Vector3(transform.position.x, transform.position.y - verticalSizeChange, transform.position.z);
            notTiny = false;
        }
    }

    public void actionCleanUp(GameObject player, bool strictCleanup)
    {
        rigidbody2D.gravityScale = originalGravity;
        transform.localScale = originalScale;
        notTiny = true;
    }
}
