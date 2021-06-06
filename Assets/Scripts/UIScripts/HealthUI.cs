using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Stack<Animator> heartContainers;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        heartContainers = new Stack<Animator>();

        foreach (Transform childTransform in gameObject.transform.GetComponentInChildren<Transform>())
        {
            heartContainers.Push(childTransform.GetComponent<Animator>());
        }
        Debug.Log(heartContainers.Count);
    }

    // Uncomment in order to test health works
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            reduceHeartContainers();
        }
    }

    public void reduceHeartContainers()
    {
        Animator heartContainer = heartContainers.Count != 0 ? heartContainers.Pop() : null;
        if(heartContainer != null)
        {
            heartContainer.SetBool("Broken", true);
        }
    }
}
