using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    public enum AIState { TargetAqu, Idle, Alert, Chase, Attack, Flee, RTB };
    public AIState currentState;
    //Last time we changed states
    protected float lastStateChangeTime;
    public GameObject target;
    public GameObject post;
    public float fleeDistance;
    public Transform[] waypoints;
    public float waypointStopDistance;
    private int currentWaypoint = 0;
    public float fieldOfView;
    public float maxViewDistance;
    public LayerMask layerMask;
    public AudioSource deathSound;
    private float soundDone;
    bool soundPlayed;
    public float killPoint;
    bool pawnDie;

    // Start is called before the first frame update
    public override void Start()
    {
<<<<<<< HEAD
        pawnDie = false;
        soundPlayed = false;
=======
>>>>>>> main
        //If theres a GameManager
        if (GameManager.instance != null)
        {
            //And it tracks players
<<<<<<< HEAD
            if (GameManager.instance.Enemies != null)
            {
                //Add the player to it's list
                GameManager.instance.Enemies.Add(this);
=======
            if (GameManager.instance.AIs != null)
            {
                //Add the player to it's list
                GameManager.instance.AIs.Add(this);
>>>>>>> main
            }
        }
        ChangeState(AIState.Idle);
        base.Start();
        TagetPlayerOne();
    }
    public void OnDestroy()
    {
        //If theres a GameManager
        if (GameManager.instance != null)
        {
            //And it tracks players
            if (GameManager.instance.Enemies != null)
            {
                //Take it off the list
                GameManager.instance.Enemies.Remove(this);
            }
        }
    }
    public void OnDestroy()
    {
        //If theres a GameManager
        if (GameManager.instance != null)
        {
            //And it tracks players
            if (GameManager.instance.AIs != null)
            {
                //Take it off the list
                GameManager.instance.AIs.Remove(this);
            }
        }
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
        base.Update();
        if (pawn == null && !soundPlayed)
        {
            deathSound.Play();
            soundPlayed = true;
        }
        Killed();
    }
<<<<<<< HEAD

=======
>>>>>>> main
    public virtual void MakeDecisions()
    {
        if (pawn != null)
        {
            DoAquireTar();
            if (target != null)
<<<<<<< HEAD
            { 
                DoAquireTar();
                switch (currentState)
                {
                    case AIState.Idle:
=======
            {
                switch (currentState)
                {
                    case AIState.Idle:
                        
>>>>>>> main
                        DoIdleState();
                        //Check for transitions
                        if (CanSee(target))
                        {
                            ChangeState(AIState.Alert);
                        }
                        break;
                    case AIState.Alert:
                        DoAlertState();
                        if (!CanSee(target))
                        {
                            ChangeState(AIState.Idle);
                        }
                        if (IsDistanceLessThan(target, 15))
                        {
                            ChangeState(AIState.Chase);
                        }
                        break;
                    case AIState.Chase:
                        DoChaseState();
                        if (IsDistanceLessThan(target, 10))
                        {
                            ChangeState(AIState.Attack);
                        }
                        if (IsDistanceGreaterThan(post, 50))
                        {
                            ChangeState(AIState.RTB);
                        }
                        if (IsHealthLessThanHalf())
                        {
                            ChangeState(AIState.Flee);
                        }
                        if (IsDistanceGreaterThan(target, 20))
                        {
                            ChangeState(AIState.RTB);
                        }
                        if (!CanSee(target))
                        {
                            ChangeState(AIState.Idle);
                        }
                        break;
                    case AIState.Attack:
                        DoAttackState();
                        if (IsHealthLessThanHalf())
                        {
                            ChangeState(AIState.Flee);
                        }
                        if (IsDistanceGreaterThan(target, 5))
                        {
                            ChangeState(AIState.Chase);
                        }
                        break;
                    case AIState.Flee:
                        DoFleeState();
                        if (!IsDistanceLessThan(post, 50))
                        {
                            ChangeState(AIState.RTB);
                        }
                        break;
                    case AIState.RTB:
                        DoRTB();
                        if (IsDistanceLessThan(target, 10))
                        {
                            ChangeState(AIState.Chase);
                        }
                        if (AmIAtBase(post, .5f))
                        {
                            ChangeState(AIState.Idle);
                        }
                        break;
                }
            }
        }
    }
    //STATES
    protected virtual void DoAquireTar()
    {
        if (target != null)
        {
            TagetPlayerOne();
        }
    }
    protected virtual void DoIdleState()
    {
        Patrol();
        DoAquireTar();
    }
    protected virtual void DoChaseState()
    {
        if(target != null)
        {
            Chase(target);
            Debug.Log("Target acquired");
        }
    }
    protected virtual void DoAttackState()
    {
        if(target != null)
        {
            Chase(target);
            if (CanSee(target))
            {
                pawn.Shoot();
            }
        }
    }
    protected virtual void DoRTB()
    {
        RTB(post);
    }
    protected virtual void DoFleeState()
    {
        Flee();
    }
    protected virtual void DoAlertState()
    {
        CanSee(target);
    }

    //BEHAVIORS
    public void RTB(GameObject postPosition)
    {
        pawn.RotateTowards(post.transform.position);
        pawn.Moveforward();
    }
    public void Chase(Pawn targetPawn)
    {
        if(targetPawn != null)
        {
            //Chase the pawn's transform
            Chase(targetPawn.transform);
        }
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
    public void Flee()
    {
        //Figures out where the target is in relation to the pawn
        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
        //Puts that point in the opposite direction
        Vector3 vectorAwayFromTarget = -vectorToTarget;
        //Takes that point and pushes it away a number of meters
        Vector3 fleeVector = vectorAwayFromTarget.normalized * fleeDistance;
        //Finds the distance from the target
        float targetDistance = Vector3.Distance(target.transform.position, pawn.transform.position);
        //Finds the percentage of the fleeDistance the target is from the targetDistance
        float percentOfFleeDistance = targetDistance / fleeDistance;
        //Makes sure that the pawn doesnt "flee" towards the target
        percentOfFleeDistance = Mathf.Clamp01(percentOfFleeDistance);
        //Inverts the percentage
        float flippedpercentOfFleeDistance = 1 - percentOfFleeDistance;
        //Moves the pawn in that direction at that distance
        Chase(pawn.transform.position + fleeVector * flippedpercentOfFleeDistance);
        
    }

    public void TagetPlayerOne()
    {
        //If GameManager exits
        if (GameManager.instance != null)
        {
            //And the array of players exist
            if (GameManager.instance.players != null)
            {
                //And there are players in it
                if (GameManager.instance.players.Count > 0)
                {
                    if(GameManager.instance.players[0].pawn.gameObject != null)
                    {
                        target = GameManager.instance.players[0].pawn.gameObject;
                    }
                    
                    //Then target the GameObject of the pawn of the first playercontroller on the list
                    
                }
            }
        }
    }
    protected void Patrol()
    {

        if (waypoints.Length > currentWaypoint)
        {
            Chase(waypoints[currentWaypoint]);
            if (Vector3.Distance(pawn.transform.position, waypoints[currentWaypoint].position) < waypointStopDistance)
            {
                currentWaypoint++;
            }
        }
        else
        {
            RestartPatrol();
        }
    }
    protected void RestartPatrol()
    {
        if (pawn.isLooping)
        {
            currentWaypoint = 0;
        }
        else
        {
            return;
        }
    }
    //TRANSITIONS
    protected bool IsDistanceLessThan(GameObject target, float distance)
    {
        if(target != null)
        {
            if (Vector3.Distance(pawn.transform.position, target.transform.position) < distance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }
    protected bool IsDistanceGreaterThan(GameObject post, float distance)
    {
        if(post != null)
        {
            if (Vector3.Distance(pawn.transform.position, post.transform.position) > distance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    protected bool AmIAtBase(GameObject post, float distance)
    {
        if(post != null)
        {
            if (Vector3.Distance(pawn.transform.position, post.transform.position) <= waypointStopDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    protected bool IsHealthLessThanHalf()
    {
        //gets the access to the Health component
        Health health = pawn.GetComponent<Health>();
        //If current health is less than or equal to max health then
        if(health != null)
        {
            if (health.currentHealth <= .5f * health.maxHealth)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    protected bool IsTargetAqu()
    {
        //return true if we have a target, false if we dont
        return (target != null);
    }
    public bool CanHear()
    {
        //Get the noiseMaker comp
        NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();
        //If they dont have it = false
        if (noiseMaker == null)
        {
            return false;
        }
        //If they arent making noise also false
        if (noiseMaker.volumeDistance <= 0)
        {
            return false;
        }
        //if they are making noise, add volumeDistance in the noiseMaker to the hearinfDistance of this AI
<<<<<<< HEAD
        if(noiseMaker.noise >= 1)
=======
        float totalDistance = noiseMaker.volumeDistance + pawn.hearingDistance;
        //if the distance between our pawn and the target is closer than this...
        if (Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance)
>>>>>>> main
        {
            float totalDistance = noiseMaker.noise + pawn.hearingDistance;
            //if the distance between our pawn and the target is closer than this...
            if (Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance)
            {
                //...then we can hear them
                return true;
            }
            else
            {
                //otherwise, we are too far to hear them
                return false;
            }
        }
        else
        {
            return false;
        }


    }
    public bool CanSee(GameObject target)
    {
      //Find the vector from the agent to the target
      Vector3 agentToTargetVector = target.transform.position - pawn.transform.position;
      //Find the angle between the direction our agent is facing
      float angleToTarget = Vector3.Angle(agentToTargetVector, pawn.transform.forward);
        //if that angle is less than our field of view and in line of sight
        if(target != null)
        {
            if (angleToTarget < fieldOfView && agentToTargetVector.magnitude <= maxViewDistance)
            {
                HasLineOfSight();
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public bool HasLineOfSight()
    {
        RaycastHit hit;
        Vector3 eyes = pawn.shooter.firePoint.transform.position + new Vector3(.5f,0);
        Vector3 agentToTargetVector = target.transform.position - eyes;
        if (Physics.Raycast(eyes, agentToTargetVector, out hit, maxViewDistance))
        {
            
            if (hit.transform.CompareTag("Player"))
            {
                Debug.DrawLine(eyes, target.transform.position, Color.white);
                pawn.RotateTowards(target.transform.position);
            }
        }
        return false;
    }
    public void Killed()
    {
        if(pawn == null && !pawnDie)
        {
            FindObjectOfType<PlayerController>().AddScore(killPoint);
            pawnDie = true;
        }
    }
}