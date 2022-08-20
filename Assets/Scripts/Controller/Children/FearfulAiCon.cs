using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearfulAiCon : AIController
{
    public enum fAIState { TargetAqu, Idle, Alert, Flee, RTB };
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
<<<<<<< HEAD
        if(pawn != null)
        {
           switch (currentState)
           {
              case AIState.Idle:
                   DoIdleState();
                   DoAquireTar();
                   if (IsDistanceLessThan(target, 10))
                   {
                       ChangeState(AIState.Alert);
                   }
                   break;
              case AIState.Alert:
                   DoAlertState();
                   if(IsDistanceLessThan(target, 5))
                   {
                       ChangeState(AIState.Flee);
                       pawn.moveSpeed = pawn.moveSpeed * 2;
                   }
                   break;
               case AIState.Flee:
                   DoFleeState();
                   if (IsDistanceGreaterThan(target, 10))
                   {
                        pawn.moveSpeed = pawn.moveSpeed / 2;
                       ChangeState(AIState.RTB);
                   }
                   break;
                case AIState.RTB:
                    DoRTB();
                    if (IsDistanceLessThan(target, 5))
                    {
                        ChangeState(AIState.Flee);
                        pawn.moveSpeed = pawn.moveSpeed * 2;
                    }
                    if (AmIAtBase(post, waypointStopDistance))
                    {
                        ChangeState(AIState.Idle);
                    }
                    break;
           }
            
        }
=======

>>>>>>> main
    }
}
