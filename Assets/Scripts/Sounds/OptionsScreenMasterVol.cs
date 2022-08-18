using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScreenMasterVol : MonoBehaviour
{
    public AudioMixer masterAudio;
    public Slider masterSlider;
    // Start is called before the first frame update
    void Start()
    {
        OnMasterVolumeChange();
    }
    public void OnMasterVolumeChange()
    {
        float newVolume = masterSlider.value;
        newVolume = Mathf.Log10(newVolume);
        newVolume = newVolume * 20;
        masterAudio.SetFloat("MasterVolume", newVolume);
    }
}
