using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    //Var to hold our Pawn
    public Pawn pawn;


    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        ProccessInputs();
    }
    public virtual void ProccessInputs()
    {

    }
}
