using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing: MonoBehaviour
{
    public float healingDone;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider player)
    {
        //Get the Health Comp from the gameObject that is being touched
        Health playerHealth = player.gameObject.GetComponent<Health>();
        //Only heal if it has Health Comp
        if(playerHealth != null)
        {
            //then only if current health is less than max health
            if(playerHealth.currentHealth < playerHealth.maxHealth)
            {
                //do heal
                playerHealth.Heal(healingDone);

                //Destroy ourselves on hit
                Destroy(gameObject);
            }
            

        }
    }
}
