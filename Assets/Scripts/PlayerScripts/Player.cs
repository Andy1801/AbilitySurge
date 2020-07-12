using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    IAbilities activeAbility;
    AbilityRotator abilityRotator;

    void Start()
    {
        activeAbility = new DoubleJumpAbility();
        // activeAbility = AbilityFactory.getRandomAbilities();
        // abilityRotator = GetComponent<AbilityRotator>();
    }

    // TODO: The small stutter could be happening because ability movement is occuring every fixed update frame but movement is happening every update frame 
    void Update()
    {
        if (activeAbility.actionCondition(gameObject))
            activeAbility.action(gameObject);
        else
            activeAbility.actionCleanUp(gameObject, false);
    }

    void LateUpdate()
    {
        // IAbilities nextAbility = abilityRotator.GetAbilities();
        // if (nextAbility != null)
        // {
        //     activeAbility.actionCleanUp(gameObject, true);
        //     activeAbility = nextAbility;
        // }
    }
}
