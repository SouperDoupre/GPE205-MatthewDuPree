using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomMap : MonoBehaviour
{
    public Toggle randomToggle;
    public bool isRandom;
    public Toggle motdToggle;
    public bool MOTD;

    public void RandomSeed()
    {
        if (randomToggle.isOn == true)
        {
            GameManager.instance.GetComponent<RoomManager>().isRandom = true;
            isRandom = true;
            motdToggle.isOn = false;
        }
        if(randomToggle.isOn == false)
        {
            GameManager.instance.GetComponent<RoomManager>().isRandom = false;
            isRandom = false;
            motdToggle.isOn = true;
        }
    }
}
