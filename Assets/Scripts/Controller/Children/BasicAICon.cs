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
<<<<<<< HEAD
        //Change the current state
        currentState = newState;
        //Save the time when we changed states
        lastStateChangeTime = Time.time;
    }
    public override void MakeDecisions()
    {
        if(pawn != null)
        {
            DoAquireTar();
            if(target != null)
            {
                switch (currentState)
                {
                    case AIState.Idle:
                        DoIdleState();
                        if(CanHear())
                        {
                            ChangeState(AIState.Alert);
                            Debug.Log("can hear");

                        }
                        break;
                    case AIState.Alert:
                        DoAlertState();
                        if (!CanHear() && lastStateChangeTime + 5 < 20)
                        {
                            ChangeState(AIState.Idle);
                        }
                        if (IsDistanceLessThan(target, 10)&&CanSee(target))
                        {
                            ChangeState(AIState.Chase);
                        }
                        if(IsDistanceGreaterThan(target, 16))
                        {
                            ChangeState(AIState.Idle);
                        }
                        break;
                    case AIState.Chase:
                        DoChaseState();
                        if(IsDistanceLessThan(target, 5)&&CanSee(target))
                        {
                            ChangeState(AIState.Attack);
                      
                        }
                        if(IsDistanceGreaterThan(target, 16))
                        {
                            ChangeState(AIState.Alert);
                        }
                        break;
                    case AIState.Attack:
                        DoAttackState();
                        if(IsDistanceGreaterThan(post, 50))
                        {
                            ChangeState(AIState.RTB);
                        }
                        if (IsHealthLessThanHalf())
                        {
                            ChangeState(AIState.Flee);
                        }
                        if (!CanSee(target))
                        {
                            ChangeState(AIState.Alert);
                            if(Time.time > lastStateChangeTime)
                            {
                                ChangeState(AIState.RTB);
                            }
                        }
                        break;
                }
            }
        }
=======
        base.ChangeState(newState);
    }
    public override void MakeDecisions()
    {

>>>>>>> main
    }
}
