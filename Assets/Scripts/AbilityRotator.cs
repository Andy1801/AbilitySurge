using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRotator : MonoBehaviour
{
    public int abilityTimerThershold;

    private float timer;
    private bool rotateAbility;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        rotateAbility = false;
        Debug.Log("Testing Rotator");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > abilityTimerThershold)
        {
            rotateAbility = true;
            timer = 0f;
        }
    }

    public IAbilities GetAbilities()
    {
        if(rotateAbility)
        {
            Debug.Log("Swapping abilites");
            rotateAbility = false;
            return AbilityFactory.getRandomAbilites();
        }

        return null;
    }
}
