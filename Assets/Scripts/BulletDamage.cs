using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damageDone;
    Rigidbody rb;
    public Pawn owner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        //Get the Health Comp from the gameObject that is being touched
        Health otherHealth = other.gameObject.GetComponent<Health>();
        //Only damage if it has Health Comp
        if(otherHealth != null)
        {
            //Do damage
            otherHealth.TakeDamage(damageDone, owner);

            //Destroy ourselves on hit
            Destroy(gameObject);
        }
    }
}
