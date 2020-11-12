using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityBar : MonoBehaviour
{

    public Text currentAbilityText;

    public void setToCurrentAbility(string abilityName)
    {
        currentAbilityText.text = abilityName;
    }
}
