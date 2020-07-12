using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: When the player turns tiny they are falling. They should be on the ground at the moment that they turn tiny as to remove a jump
public class TinyAbility : IAbilities
{
    private const float X = 0.5f, Y = 0.5f, Z = 1f;

    Vector3 originalScale = Vector3.zero;
    Vector3 tinyScale = new Vector3(X, Y, Z);

    private Renderer playerRenderer;
    private Transform transform;

    public bool actionCondition(GameObject player)
    {
        playerRenderer = player.GetComponent<MeshRenderer>();
        playerRenderer.material.SetColor("_Color", Color.white);

        Transform transform = player.GetComponent<Transform>();
        Debug.Log(transform);

        if (originalScale == Vector3.zero)
            originalScale = transform.localScale;

        return Input.GetKey(KeyCode.Space);
    }

    public void action(GameObject player)
    {
        transform = player.GetComponent<Transform>();

        transform.localScale = tinyScale;
    }

    public void actionCleanUp(GameObject player, bool strictCleanup)
    {
        transform = player.GetComponent<Transform>();

        transform.localScale = originalScale;
    }
}
