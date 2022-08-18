using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ScoreFruitPowerup : Powerup
{
    public Powerup powerup;
    public float scoreIncrease;
    Pawn pawn;
    
    public override void Apply(PowerupManager target)
    {
        pawn = target.GetComponent<Pawn>();
        GameManager.FindObjectOfType<PlayerController>().AddScore(scoreIncrease);
    }

    public override void Remove(PowerupManager target)
    {
        //this is permanent
    }
}
