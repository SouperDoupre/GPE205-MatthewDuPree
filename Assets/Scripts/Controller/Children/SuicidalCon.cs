using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicidalCon : AIController
{
    public enum sAIState {TargetAqu, Idle, Chase};
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }
    // Update is called once per frame
    public override void Update()
    {
        MakeDecisions();
        base.Update();
    }
    public override void ChangeState(AIState newState)
    {
        base.ChangeState(newState);
    }
    public override void MakeDecisions()
    {
        if(pawn != null)
        {
            switch (currentState)
            {
                case AIState.Idle:
                    DoIdleState();
                    DoAquireTar();
                    if (IsDistanceLessThan(target, 10))
                    {
                        ChangeState(AIState.Chase);
                    }
                    break;
                case AIState.Chase:
                    DoBomberState();
                    if(IsDistanceGreaterThan(target, 15))
                    {
                        ChangeState(AIState.RTB);
                    }
                    break;
                case AIState.RTB:
                    DoRTB();
                    if (AmIAtBase(post, .5f))
                    {
                        ChangeState(AIState.Idle);
                    }
                    break;
            }
        }
        else
        {
            return;
        }

    }
    public void DoBomberState()
    {
        Chase(target);
    }
}
