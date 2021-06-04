using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TODO: Change with timer classes when implemented 
public class AbilityRotator : MonoBehaviour
{
    public int abilityTimerThreshold;
    private Timer timer;
    private bool rotateAbility;
    private Image nextAbilityIcon;

    private string currentAbility;
    IAbilities nextAbility = null;

    void Start()
    {
        timer = new Timer(abilityTimerThreshold);
        timer.StartTimer();
        rotateAbility = false;
        nextAbilityIcon = GameObject.FindGameObjectWithTag("AbilityUI").GetComponent<Image>();
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
        {
            newAbility = GetAbilities();
            nextAbility = GetAbilities();
            nextAbilityIcon.color = nextAbility.GetColor();
        }
        else if (rotateAbility)
        {
            newAbility = nextAbility;
            nextAbility = GetAbilities();
            nextAbilityIcon.color = nextAbility.GetColor();
        }
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
