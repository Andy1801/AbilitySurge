using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnGizmos : MonoBehaviour
{
    void OnDrawGizmos()
    {

        Vector3 rightEndPosition = Vector3.zero;
        Vector3 leftEndPosition = Vector3.zero;

        rightEndPosition.x = transform.position.x + transform.localScale.x / 2;
        rightEndPosition.y = transform.position.y + transform.localScale.y / 2;

        leftEndPosition.x = transform.position.x - transform.localScale.x / 2;
        leftEndPosition.y = transform.position.y - transform.localScale.y / 2;


        Gizmos.DrawLine(transform.position, rightEndPosition);
        Gizmos.DrawLine(transform.position, leftEndPosition);
    }
}
