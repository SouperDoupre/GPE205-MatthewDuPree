using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ShieldPowerup : Powerup
{
    public ShieldPowerup powerup;
    public override void Apply(PowerupManager target)
    {
        ShieldActivate activate = target.gameObject.GetComponent<ShieldActivate>();
        Health health = target.gameObject.GetComponent<Health>();
        activate.playerShield.SetActive(true);
        health.GetComponent<Health>().enabled = false;
    }
    public override void Remove(PowerupManager target)
    {
        ShieldActivate activate = target.gameObject.GetComponent<ShieldActivate>();
        Health health = target.gameObject.GetComponent<Health>();
        if (duration < Time.time)
        {
            activate.playerShield.SetActive(false);
            health.GetComponent<Health>().enabled = true;

        }
    }
}