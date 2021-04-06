using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: See if I can add the camera offset to the position to keep the boundaries correct without it being in position zero
public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private Renderer playerRenderer;
    private float playerWidth;
    private float playerHeight;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        playerRenderer = transform.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        playerWidth = playerRenderer.bounds.extents.x;
        playerHeight = playerRenderer.bounds.extents.y;

        Vector3 viewPos = transform.position;

        float positiveHorizontalBoundary = screenBounds.x;
        float negativeHorizontalBoundary = screenBounds.x - (Camera.main.transform.position.x * 2);


        float positiveVerticalBoundary = screenBounds.y;
        float negativeVerticalBoundary = screenBounds.y - (Camera.main.transform.position.y * 2);

        viewPos.x = Mathf.Clamp(viewPos.x, negativeHorizontalBoundary * -1 + playerWidth, positiveHorizontalBoundary - playerWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, negativeVerticalBoundary * -1 + playerHeight, positiveVerticalBoundary - playerHeight);

        transform.position = viewPos;

    }
}
