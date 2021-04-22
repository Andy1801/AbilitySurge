using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Turn into properties
public class PlayerPrefManager : MonoBehaviour
{
    // Set constant list
    private const string VOLUME_KEY = "volume";

    public static void setVolume(float volume)
    {
        PlayerPrefs.SetFloat(VOLUME_KEY, volume);
    }

    public static float getVolume()
    {
        return PlayerPrefs.GetFloat(VOLUME_KEY);
    }

    public static bool checkKeyValue()
    {
        return PlayerPrefs.HasKey(VOLUME_KEY);
    }

    public void savePlayerPref()
    {
        PlayerPrefs.Save();
    }
}
