using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OPSAmbientVolume : MonoBehaviour
{
    public AudioMixer ambientAudio;
    public Slider ambientSlider;
    // Start is called before the first frame update
    void Start()
    {
        OnAmbientVolumeChange();
    }
    public void OnAmbientVolumeChange()
    {
        float newVolume = ambientSlider.value;
        newVolume = Mathf.Log10(newVolume);
        newVolume = newVolume * 20;
        ambientAudio.SetFloat("AmbientVolume", newVolume);
    }
}
