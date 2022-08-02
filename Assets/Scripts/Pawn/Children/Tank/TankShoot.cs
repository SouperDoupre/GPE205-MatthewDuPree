using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : Shooter
{
    // Start is called before the first frame update
    public override void Start()
    {
        

    }

    // Update is called once per frame
    public override void Update()
    {
        
    }
    public override void Shoot(GameObject bullet, float bulletSpeed, float damageDone, float lifespan)
    {
        
        //Create new bullet
        GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as GameObject;
        //Get bulletDamage
        BulletDamage bD = newBullet.GetComponent<BulletDamage>();
        //If it can do damage
        if(bD != null)
        {
            //this is how much damage it does
            bD.damageDone = damageDone;
            //this is who the bullet belongs to
            bD.owner = GetComponent<Pawn>();
        }
        //get the Rigidbody
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        //Check to see if it has one...
        if(rb != null)
        {
            //Make it move forward
            rb.AddForce(firePoint.forward * bulletSpeed);
        }
        Destroy(newBullet, lifespan);
    }
}