using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Look up how a factory pattern should actually be built. Make some form of having the class be able to communicate the type that it should be
// TODO: Think about a pub/sub pattern approach in order to fix the factory 
public static class AbilityFactory
{
    static List<string> abilityList = new List<string>();

    static AbilityFactory()
    {
        abilityList.Add("gliding");
        abilityList.Add("tiny");
        abilityList.Add("dash");
        abilityList.Add("doubleJump");
    }

    public static IAbilities getRandomAbilities()
    {
        //Get a random item from list
        string abilityName = abilityList.ToArray()[Random.Range(0, abilityList.Count)];
        Debug.Log(abilityName);
        return GetAbilities(abilityName);
    }

    private static IAbilities GetAbilities(string abilityName)
    {
        switch (abilityName)
        {
            case "gliding":
                return new GlideAbility();
            case "tiny":
                return new TinyAbility();
            case "dash":
                return new DashAbility();
            case "doubleJump":
                return new DoubleJumpAbility();
            default:
                return null;
        }
    }
}
