using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    IAbilities activeAbility;
    AbilityRotator abilityRotator;

    // Start is called before the first frame update
    void Start()
    {
        activeAbility = AbilityFactory.getRandomAbilites();
        abilityRotator = GetComponent<AbilityRotator>();
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

    void LateUpdate()
    {
        IAbilities nextAbility = abilityRotator.GetAbilities();

        if(nextAbility != null)
        {
            activeAbility.actionCleanUp(gameObject);
            activeAbility = nextAbility;
        }
    }
}
