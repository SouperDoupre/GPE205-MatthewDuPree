using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    //Var for move speed
    public float moveSpeed;
    //Var for turn speed
    public float turnSpeed;
    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public abstract void Moveforward();
    public abstract void Movebackward();
    public abstract void LookRight();
    public abstract void LookLeft();

}
