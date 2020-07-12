using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private float playerWidth;
    private float playerHeight;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        playerWidth = transform.GetComponent<Renderer>().bounds.extents.x;
        playerHeight = transform.GetComponent<Renderer>().bounds.extents.y;
        Debug.Log(screenBounds);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;

        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + playerWidth, screenBounds.x - playerWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + playerHeight, screenBounds.y - playerHeight);

        transform.position = viewPos;

    }
}
