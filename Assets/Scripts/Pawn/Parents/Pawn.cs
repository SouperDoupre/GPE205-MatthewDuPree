using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    //Var to hold shooter comp
    public Shooter shooter;
    //Var to hold bullet
    public GameObject bullet;
    //Var to hold how fast bullet go
    public float bulletSpeed;
    //Var to hold how long bullet is live if it doesnt hit something
    public float lifespan;
    //Var for rate of fire
    public float fireRate;
    //Var to hold the movement comp
    public Movement move;
    //Var for move speed
    public float moveSpeed;
    //Var for turn speed
    public float lookSpeed;
    //Var to hold how far can hear
    public float hearingDistance;
    public bool isLooping;
    public float damageDone;
<<<<<<< HEAD
    public Controller controller;


=======
  
    
>>>>>>> main

    // Start is called before the first frame update
    public virtual void Start()
    {
        move = GetComponent<Movement>();
        shooter = GetComponent<Shooter>();
   
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }



    public abstract void Moveforward();
    public abstract void Movebackward();
    public abstract void LookRight();
    public abstract void LookLeft();
    public abstract void Shoot();
    public abstract void RotateTowards(Vector3 tagetPosition);
}
