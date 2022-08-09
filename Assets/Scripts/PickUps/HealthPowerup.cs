using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class HealthPowerup : Powerup
{
    public float healthToAdd;
    public override void Apply(PowerupManager target)
    {
        //Get the Health Comp from the gameObject that is being touched
        Health playerHealth = target.gameObject.GetComponent<Health>();
        if(playerHealth != null)
        {
            playerHealth.Heal(healthToAdd, target.GetComponent<Pawn>());
        }
    }
    public override void Remove(PowerupManager target)
    {
        //TODO : Remove health changes
    }
}
