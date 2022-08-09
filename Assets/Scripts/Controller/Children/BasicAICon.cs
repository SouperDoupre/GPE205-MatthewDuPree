using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAICon : AIController
{
    public enum bAIState { TargetAqu, Idle, Alert, Chase, Attack, Flee, RTB };
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
    public override void ChangeState(AIState newState)
    {
        base.ChangeState(newState);
    }
    public override void MakeDecisions()
    {

    }
}
