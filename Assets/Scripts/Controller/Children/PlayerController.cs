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
        //Runs data from parent class Controller in Start()
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        //Runs data from parent class Controller in Update()
        base.Update();
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
