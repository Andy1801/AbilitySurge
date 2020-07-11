using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: When the player turns tiny they are falling. They should be on the ground at the momemnt that they turn tiny as to remove a jump
public class TinyAbility : IAbilities
{
    private const float X = 0.5f;
    private const float Y = 0.5f;
    private const float Z = 1f;

    Vector3 originalScale = Vector3.zero;
    Vector3 tinyScale = new Vector3(X, Y, Z);

    public bool actionCondition(GameObject player)
    {
        Transform transform = player.GetComponent<Transform>();

        if (originalScale == Vector3.zero)
            originalScale = transform.localScale;


        return Input.GetKey(KeyCode.Space);
    }

    public void action(GameObject player)
    {
        Transform transform = player.GetComponent<Transform>();

        transform.localScale = tinyScale;
    }

    public void actionCleanUp(GameObject player)
    {
        Transform transform = player.GetComponent<Transform>();

        transform.localScale = originalScale;
    }
}
