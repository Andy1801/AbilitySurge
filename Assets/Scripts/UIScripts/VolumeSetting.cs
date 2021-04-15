using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSetting : MonoBehaviour
{
    private const float MAX_VOLUME = 100f;

    public Slider volumeSlider;
    public TMP_InputField volumeInputText;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
        volumeInputText.text = (audioSource.volume * MAX_VOLUME).ToString();
    }

    public void volumeChangeFromText()
    {
        float volume = convertVolumeText();
        volumeSlider.value = volume <= MAX_VOLUME ? volume / MAX_VOLUME : MAX_VOLUME / MAX_VOLUME;
    }

    public void volumeChangeFromSlider()
    {
        string volumeText = (volumeSlider.value * MAX_VOLUME).ToString("n1");
        volumeInputText.text = volumeText;
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
}
