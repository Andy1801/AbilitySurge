using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    IAbilities activeAbility;

    // Start is called before the first frame update
    void Start()
    {
        //For testing
        activeAbility = new DashAbility();
    }

    // TODO: The small studder could be happening because ability movement is occuring every fixed update frame but movement is happening every update frame 
    // Update is called once per frame
    void FixedUpdate()
    {
        if (activeAbility.actionCondition(gameObject))
            activeAbility.action(gameObject);
        else
            activeAbility.actionCleanUp(gameObject);
    }
}
