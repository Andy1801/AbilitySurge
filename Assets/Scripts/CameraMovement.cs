using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO Fix camera vertical movement
//TODO Think about removing/rewriting
public class CameraMovement : MonoBehaviour
{

    public GameObject player;

    private Vector3 cameraOffset;

    public float verticalOffset;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - player.transform.position;
        cameraOffset.y = cameraOffset.y + verticalOffset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + cameraOffset;
    }
}
