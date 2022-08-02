using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    Rigidbody rb;
    private float lastTimeShot;
    AIController controller;
    public override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<AIController>();
    }
    public override void Update()
    {
        base.Update();
    }
    public override void Movebackward()
    {
        if(rb != null)
        {
            move.Move(transform.forward, -moveSpeed);
        }
    }
    public override void Moveforward()
    {
        if (rb != null)
        {
           move.Move(transform.forward, moveSpeed);
        }
    }
    public override void LookRight()
    {
        if( rb != null)
        {
            move.Rotate(lookSpeed);
        }
    }
    public override void LookLeft()
    {
        if(rb != null)
        {
            move.Rotate(-lookSpeed);
        }
    }
    public override void Shoot()
    {
        float secondsPerShot = 1 / fireRate;
        if(Time.time > lastTimeShot + secondsPerShot)
        {
            if (rb != null)
            {
                shooter.Shoot(bullet, bulletSpeed, damageDone, lifespan);
            }
            lastTimeShot = Time.time;
        }
    }
    public override void RotateTowards(Vector3 targetPosition)
    {
        if(rb != null)
        {
            //Finds the direction to look in
            Vector3 vectorToTarget = targetPosition - transform.position;
            //Instructions on how to look in that direction, using just this will make the pawn snap to that direction like a horror movie
            Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);
            //Restricts the speed of rotation to the lookSpeed
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, lookSpeed * Time.deltaTime);
        }
    }
}
