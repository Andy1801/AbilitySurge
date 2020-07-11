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
    }

    public static IAbilities getRandomAbilites()
    {
        //Get a random item from list
        string abilityName = abilityList.ToArray()[Random.Range(0, abilityList.Count)];

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
            default:
                return null;
        }
    }
}
