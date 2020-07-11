using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    IAbilites activeAbility;

    // Start is called before the first frame update
    void Start()
    {
        //For testing
        activeAbility = new GlideAbility();
    }

    // Update is called once per frame
    void Update()
    {
        if(activeAbility.actionCondition(gameObject))
            activeAbility.action(gameObject);
        else
            activeAbility.actionCleanUp(gameObject);
    }
}
