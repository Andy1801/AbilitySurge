using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Look up how a factory pattern should actually be built. Make some form of having the class be able to communicate the type that it should be
// TODO: Think about a pub/sub pattern approach in order to fix the factory 
public static class AbilityFactory
{
    static HashSet<string> abilityList = new HashSet<string>();

    static AbilityFactory()
    {
        abilityList.Add("Gliding");
        abilityList.Add("Tiny");
        abilityList.Add("Dash");
        abilityList.Add("Double Jump");
    }

    public static (IAbilities ability, string abilityName) getRandomAbilities(string currentAbility)
    {
        string[] currentAbilityList = getCurrentAbilityList(currentAbility);

        //Get a random item from list
        string abilityName = currentAbilityList[Random.Range(0, currentAbilityList.Length)];
        // Debug.Log(abilityName);
        return (GetAbilities(abilityName), abilityName);
    }

    private static string[] getCurrentAbilityList(string currentAbility)
    {
        abilityList.Remove(currentAbility);

        string[] currentAbilityList = new string[abilityList.Count];

        abilityList.CopyTo(currentAbilityList);
        abilityList.Add(currentAbility);

        return currentAbilityList;
    }

    private static IAbilities GetAbilities(string abilityName)
    {
        switch (abilityName)
        {
            case "Gliding":
                return new GlideAbility();
            case "Tiny":
                return new TinyAbility();
            case "Dash":
                return new DashAbility();
            case "Double Jump":
                return new DoubleJumpAbility();
            default:
                return null;
        }
    }
}
