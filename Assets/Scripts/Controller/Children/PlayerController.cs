using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public KeyCode moveForewardKey;
    public KeyCode moveBackwardKey;
    public KeyCode lookRightKey;
    public KeyCode lookLeftKey;
    public KeyCode shootKey;
    // Start is called before the first frame update
    public override void Start()
    {
        //If theres a GameManager
        if(GameManager.instance != null)
        {
            //And it tracks players
            if(GameManager.instance.players != null)
            {
                //Add the player to it's list
                GameManager.instance.players.Add(this);
            }
        }
        //Runs data from parent class Controller in Start()
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        //Runs data from parent class Controller in Update()
        base.Update();
    }
    public void OnDestroy()
    {
        //If theres a GameManager
        if(GameManager.instance != null)
        {
            //And it tracks players
            if(GameManager.instance.players != null)
            {
                //Take it off the list
                GameManager.instance.players.Remove(this);
            }
        }
    }

    public override void ProccessInputs()
    {
        if (Input.GetKey(moveForewardKey))
        {
            pawn.Moveforward();
        }
        
        if (Input.GetKey(moveBackwardKey))
        {
            pawn.Movebackward();
        }
        
        if (Input.GetKey(lookRightKey))
        {
            pawn.LookRight();
        }

        if (Input.GetKey(lookLeftKey))
        {
            pawn.LookLeft();
        }
        
        if (Input.GetKeyDown(shootKey))
        {
            Debug.Log("Shot");
        }
    }
}
