using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Change with timer classes when implemented 
public class AbilityRotator : MonoBehaviour
{
    public int abilityTimerThreshold;
    private Timer timer;
    private bool rotateAbility;

    private string currentAbility;

    void Start()
    {
        timer = new Timer(abilityTimerThreshold);
        timer.StartTimer();
        rotateAbility = false;
    }

    void Update()
    {

        if (timer.getTimerStatus())
        {
            rotateAbility = true;
            timer.StartTimer();
        }
    }

    public IAbilities checkAbilityStatus()
    {
        IAbilities newAbility = null;

        if (currentAbility == null)
            newAbility = GetAbilities();
        else if (rotateAbility)
            newAbility = GetAbilities();

        return newAbility;
    }

    private IAbilities GetAbilities()
    {
        rotateAbility = false;
        var abilityDetails = AbilityFactory.getRandomAbilities(currentAbility);
        currentAbility = abilityDetails.abilityName;


        return abilityDetails.ability;
    }
}
