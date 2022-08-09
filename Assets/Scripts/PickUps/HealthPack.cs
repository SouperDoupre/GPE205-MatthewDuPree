using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack: MonoBehaviour
{
    public HealthPowerup powerup;

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
        // variable to store other object's PowerupController - if it has one
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();
        Health health = other.GetComponent<Health>();

        // If the other object has a PowerupController
        if (powerupManager != null)
        {
            if(health.currentHealth < health.maxHealth)
            {
                // Add the powerup
                powerupManager.Add(powerup);
                // Destroy this pickup
                Destroy(gameObject);
            }
        }
    }
}
