using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    public enum AIState { Idle, Chase, Attack,  RTB};
    public AIState currentState;
    //Last time we changed states
    private float lastStateChangeTime;
    public GameObject target;
    public GameObject post;
    
    // Start is called before the first frame update
    public override void Start()
    {
        ChangeState(AIState.Idle);
        base.Start();
    }
    public virtual void ChangeState(AIState newState)
    {
        //Change the current state
        currentState = newState;
        //Save the time when we changed states
        lastStateChangeTime = Time.time;
    }

    // Update is called once per frame
    public override void Update()
    {
        MakeDecisions();
        base.Update() ;
    }
    public void MakeDecisions()
    {
        switch (currentState)
        {
            case AIState.Idle:
                //Do work
                DoIdleState();
                //Check for transitions
                if (IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIState.Chase);
                }
                break;
            case AIState.Chase:
                DoChaseState();
                if (!IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIState.RTB);
                }
                if(IsDistanceLessThan(target, 5))
                {
                    ChangeState(AIState.Attack);
                }
                if (IsDistanceGreaterThan(post, 50))
                {
                    ChangeState(AIState.RTB);
                }
                break;
            case AIState.Attack:
                DoAttackState();
                if(!IsDistanceLessThan(target, 4))
                {
                    ChangeState(AIState.Chase);
                }
                break;
            case AIState.RTB:
                DoRTB();
                if(IsDistanceLessThan(target, 5))
                {
                    ChangeState(AIState.Chase);
                }
                if (AmIAtBase(post, .5f))
                {
                    ChangeState(AIState.Idle);
                }
                break;

        }
        Debug.Log("Making decisions");
    }
    //STATES
    protected virtual void DoIdleState()
    {
        //Do nothing
        Debug.Log("Doing nothing");
    }
    protected virtual void DoScanState()
    {
        //Look for player
        Debug.Log("Looking around");
    }

    protected virtual void DoChaseState()
    {
        Chase(target);
        Debug.Log("Target acquired");
    }
    public virtual void DoRTB()
    {
        RTB(post);
    }
    public virtual void DoAttackState()
    {
        Chase(target);
        Shoot();
    }


    //BEHAVIORS
    public void Alert()
    {
        //Rotate in place
        Debug.Log("On Alert");
    }
    public void RTB(GameObject postPosition)
    {
        pawn.RotateTowards(post.transform.position);
        pawn.Moveforward();
    }
    public void Chase(Pawn targetPawn)
    {
        //Chase the pawn's transform
        Chase(targetPawn.transform);
    }
    public void Chase(Transform targetTransform)
    {
        //Chase position of our target Transform
        Chase(targetTransform.position);
    }
    public void Chase(Vector3 targetPosition)
    {
        pawn.RotateTowards(targetPosition);
        pawn.Moveforward();
    }
    public void Chase(GameObject targetPostion)
    {
        pawn.RotateTowards(target.transform.position);
        pawn.Moveforward();
        Debug.Log("Seeking target");
    }
    public void Shoot()
    {
        pawn.Shoot();
    }



    //TRANSITIONS
    protected bool IsDistanceLessThan(GameObject target, float distance)
    {
        if(Vector3.Distance(pawn.transform.position, target.transform.position) < distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected bool IsDistanceGreaterThan(GameObject post, float distance)
    {
        if(Vector3.Distance(pawn.transform.position, post.transform.position) > distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected bool AmIAtBase(GameObject post, float distance)
    {
        if(Vector3.Distance(pawn.transform.position, post.transform.position) <= distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected bool IsPlayerStillInRange(GameObject target, float time)
    {
        if(Time.time > time)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
