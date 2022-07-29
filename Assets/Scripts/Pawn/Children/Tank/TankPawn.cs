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
    public override void RotateTowards(Vector3 targetPosition)
    {
        //Finds the direction to look in
        Vector3 vectorToTarget = targetPosition - transform.position;
        //Instructions on how to look in that direction, using just this will make the pawn snap to that direction like a horror movie
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);
        //Restricts the speed of rotation to the lookSpeed
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, lookSpeed * Time.deltaTime);
    }
}
