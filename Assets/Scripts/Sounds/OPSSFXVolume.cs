using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OPSSFXVolume : MonoBehaviour
{
    public AudioMixer sfxAudio;
    public Slider sfxSlider;
    // Start is called before the first frame update
    void Start()
    {
        OnSFXVolumeChange();
    }
    public void OnSFXVolumeChange()
    {
        float newVolume = sfxSlider.value;
        newVolume = Mathf.Log10(newVolume);
        newVolume = newVolume * 20;
        sfxAudio.SetFloat("SFXVolume", newVolume);
    }
}
