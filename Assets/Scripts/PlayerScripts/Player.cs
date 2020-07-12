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
        activeAbility = AbilityFactory.getRandomAbilities();
        abilityRotator = GetComponent<AbilityRotator>();
    }

    // TODO: The small stutter could be happening because ability movement is occuring every fixed update frame but movement is happening every update frame 
    // Update is called once per frame
    void Update()
    {
        if (activeAbility.actionCondition(gameObject))
            activeAbility.action(gameObject);
        else
            activeAbility.actionCleanUp(gameObject, false);
    }

    void LateUpdate()
    {
        IAbilities nextAbility = abilityRotator.GetAbilities();
        if (nextAbility != null)
        {
            activeAbility.actionCleanUp(gameObject, true);
            activeAbility = nextAbility;
        }
    }
}
