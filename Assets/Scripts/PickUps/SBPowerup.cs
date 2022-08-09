using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SBPowerup : Powerup
{
    public Powerup powerup;
    private float boostAsPercent;
    public int boostPercent;
    private Pawn move;

    public override void Apply(PowerupManager target)
    {
        move = target.gameObject.GetComponent<Pawn>();
        boostAsPercent = 100 / boostPercent;
        move.moveSpeed = move.moveSpeed * boostAsPercent;
        
    }
    public override void Remove(PowerupManager target)
    {
        if(Time.time > duration)
        {
            move.moveSpeed = move.moveSpeed / boostAsPercent;
        }
    }
}
