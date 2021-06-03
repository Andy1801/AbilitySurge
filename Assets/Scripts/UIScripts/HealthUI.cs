using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Stack<Image> heartContainers;

    // Start is called before the first frame update
    void Start()
    {
        heartContainers = new Stack<Image>();

        foreach (Transform childTransform in gameObject.transform.GetComponentInChildren<Transform>())
        {
            heartContainers.Push(childTransform.GetChild(0).GetComponent<Image>());
        }
        Debug.Log(heartContainers.Count);
    }

    // Uncomment in order to test health works
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.P))
    //     {
    //         reduceHeartContainers();
    //     }
    // }

    public void reduceHeartContainers()
    {
        Image heartContainer = heartContainers.Count != 0 ? heartContainers.Pop() : null;

        if (heartContainer != null)
            heartContainer.fillAmount = 0;
    }
}
