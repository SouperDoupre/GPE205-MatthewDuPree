using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DUPowerup : Powerup
{
    public DUPowerup powerup;
    private float boostAsPercent;
    public int boostPercent;
    private Pawn damage;
    public override void Apply(PowerupManager target)
    {
        damage = target.gameObject.GetComponent<Pawn>();
        boostAsPercent = 100 / boostPercent;
        damage.damageDone = damage.damageDone * boostAsPercent;
    }
    public override void Remove(PowerupManager target)
    {
        if(Time.time > duration)
        {
            if (isPerma == false)
            {
                damage.damageDone = damage.damageDone / boostAsPercent;
            }
        }
    }
}
