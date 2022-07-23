using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        base.Update();
    }
    public override void Movebackward()
    {
        Debug.Log("Move Backward");
    }
    public override void Moveforward()
    {
        Debug.Log("Move Foreward");
    }
    public override void LookRight()
    {
        Debug.Log("Look Right");
    }
    public override void LookLeft()
    {
        Debug.Log("Look Left");
    }
}
