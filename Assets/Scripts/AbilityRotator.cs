using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRotator : MonoBehaviour
{
    public int abilityTimerThreshold;
    private float timer;
    private bool rotateAbility;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        rotateAbility = false;
    }

    // Update is called once per frame
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
