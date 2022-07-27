using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        base.Update();
    }
    public override void Movebackward()
    {
        move.Move(transform.forward, -moveSpeed);
    }
    public override void Moveforward()
    {
        move.Move(transform.forward, moveSpeed);
    }
    public override void LookRight()
    {
        move.Rotate(lookSpeed);
    }
    public override void LookLeft()
    {
        move.Rotate(-lookSpeed);
    }
    public override void Shoot()
    {
        shooter.Shoot(bullet, bulletSpeed, damageDone, lifespan);
    }
}
