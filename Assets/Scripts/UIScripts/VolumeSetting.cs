using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSetting : MonoBehaviour
{

    // Constant list for playerPref
    private const string VOLUME_KEY = "volume";
    private const string MUTE_KEY = "mute";

    // Constant for volume
    private const float MAX_VOLUME = 100f;

    public Toggle muteToggle;
    public Slider volumeSlider;
    public TMP_InputField volumeInputText;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();

        float volume = PlayerPrefManager.checkKeyValue(VOLUME_KEY) ? PlayerPrefManager.getVolume(VOLUME_KEY) : audioSource.volume;
        bool isMute = PlayerPrefManager.checkKeyValue(MUTE_KEY) ? PlayerPrefManager.getMute(MUTE_KEY) : false;

        Debug.Log("Is muted on start: " + isMute);
        changeMuteOption(isMute);
        volumeInputText.text = (volume * MAX_VOLUME).ToString();
        audioSource.volume = volume;
        volumeChangeFromText();
        volumePrefChange(volume);
    }

    public void volumeChangeFromText()
    {
        float volume = convertVolumeText();
        volumeSlider.value = volume <= MAX_VOLUME ? volume / MAX_VOLUME : MAX_VOLUME / MAX_VOLUME;
        changeMuteOption(false);
        volumePrefChange(volume / MAX_VOLUME);
    }

    public void volumeChangeFromSlider()
    {
        string volumeText = (volumeSlider.value * MAX_VOLUME).ToString("n1");
        volumeInputText.text = volumeText;
        changeMuteOption(false);
        volumePrefChange(volumeSlider.value);
    }

    public void toggleMute()
    {
        changeMuteOption(audioSource.mute);
    }

    private void changeMuteOption(bool isMuted)
    {
        PlayerPrefManager.setMute(MUTE_KEY, isMuted.ToString());
        audioSource.mute = isMuted;
        muteToggle.isOn = isMuted;
    }


    private float convertVolumeText()
    {
        float volume;

        if (String.IsNullOrEmpty(volumeInputText.text.Trim()))
        {
            volume = audioSource.volume;
        }
        else
        {
            volume = float.Parse(volumeInputText.text);
        }

        return volume;
    }

    private void volumePrefChange(float volume)
    {
        PlayerPrefManager.setVolume(VOLUME_KEY, volume);
    }


}
