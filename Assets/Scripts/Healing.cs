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
        //Only damage if it has Health Comp
        if(playerHealth != null)
        {
            //Do damage
            playerHealth.Heal(healingDone);

            //Destroy ourselves on hit
            Destroy(gameObject);
        }
    }
}
