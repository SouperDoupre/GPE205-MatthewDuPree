using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturntoMenuButton : MonoBehaviour
{
    public void ReturntoMenu()
    {
        if(GameManager.instance != null)
        {
            GameManager.instance.ActivateTitleScreen();
            Time.timeScale = 0f;
        }
    }
}
