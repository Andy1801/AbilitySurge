using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AbilityFactory
{
    static List<string> abilityList = new List<string>();

    static AbilityFactory()
    {
        abilityList.Add("gliding");
        abilityList.Add("tiny");
        abilityList.Add("dash");
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
            default:
                return null;
        }
    }
}
