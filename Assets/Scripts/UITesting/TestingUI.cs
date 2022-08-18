using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingUI : MonoBehaviour
{
    public GameManager game;
    RoomManager room;
    // Start is called before the first frame update
    void Start()
    {
        game = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }
   
}
