using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Turn into properties/delegates
public class PlayerPrefManager : MonoBehaviour
{

    public static void setVolume(string volumeKey, float volume)
    {
        PlayerPrefs.SetFloat(volumeKey, volume);
    }

    public static void setMute(string muteKey, string isMute)
    {
        PlayerPrefs.SetString(muteKey, isMute);
    }

    public static void setScreenMode(string screenKey, string isFullScreen)
    {
        PlayerPrefs.SetString(screenKey, isFullScreen);
    }

    public static bool getMute(string muteKey)
    {
        string muteString = PlayerPrefs.GetString(muteKey);

        return muteString.Equals("True");
    }

    public static float getVolume(string volumeKey)
    {
        return PlayerPrefs.GetFloat(volumeKey);
    }

    public static bool getScreenMode(string screenKey)
    {
        string screenModeString = PlayerPrefs.GetString(screenKey);

        return screenModeString.Equals("True");
    }

    public static bool checkKeyValue(string key)
    {
        return PlayerPrefs.HasKey(key);
    }

    public void savePlayerPref()
    {
        PlayerPrefs.Save();
    }
}
