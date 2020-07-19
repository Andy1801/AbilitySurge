using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Change with timer classes when implemented 
public class AbilityRotator : MonoBehaviour
{
    public int abilityTimerThreshold;
    private float timer;
    private bool rotateAbility;

    void Start()
    {
        timer = 0f;
        rotateAbility = false;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > abilityTimerThreshold)
        {
            rotateAbility = true;
            timer = 0f;
        }
    }

    public IAbilities GetAbilities()
    {
        if (rotateAbility)
        {
            rotateAbility = false;
            return AbilityFactory.getRandomAbilities();
        }

        return null;
    }
}
