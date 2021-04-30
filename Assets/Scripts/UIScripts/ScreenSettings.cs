using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSettings : MonoBehaviour
{
    private const string SCREEN_MODE_KEY = "screenMode";

    public Toggle fullScreenToggle;


    // Start is called before the first frame update
    void Start()
    {
        bool screenMode = PlayerPrefManager.checkKeyValue(SCREEN_MODE_KEY) ? PlayerPrefManager.getScreenMode(SCREEN_MODE_KEY) : true;
        updateScreenMode(screenMode);
    }

    public void toggleScreenMode()
    {
        updateScreenMode(!PlayerPrefManager.getScreenMode(SCREEN_MODE_KEY));
    }

    private void updateScreenMode(bool screenMode)
    {
        PlayerPrefManager.setScreenMode(SCREEN_MODE_KEY, screenMode.ToString());
        Screen.fullScreen = screenMode;
    }


}
