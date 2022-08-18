using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButon : MonoBehaviour
{
    public void StartGame()
    {
        if(GameManager.instance != null)
        {
            GameManager.instance.GameStart();
            Time.timeScale = 1;
        }
    }
}
