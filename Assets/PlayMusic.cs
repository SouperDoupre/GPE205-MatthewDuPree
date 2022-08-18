using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    AudioSource music;

    private void Start()
    {
        music = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(GameManager.instance.currentState == GameManager.GameStates.Gameplay)
        {
            music.Play();
            Debug.Log("playing music");
        }
        if(GameManager.instance.currentState != GameManager.GameStates.Gameplay)
        {
            music.Pause();
        }
    }
}
