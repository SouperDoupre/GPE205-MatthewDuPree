using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damageDone;
    public Pawn owner;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider enemy)
    {
        //Get the Health Comp from the gameObject that is being touched
        Health enemyHealth = enemy.gameObject.GetComponent<Health>();
       
        //Only damage if it has Health Comp
        if(enemyHealth != null)
        {
            //Call the TakeDamage function inside the enemy health component
            enemyHealth.TakeDamage(damageDone, owner);
        }
        //Destroy ourselves on hit
        Destroy(gameObject);
    }
}
