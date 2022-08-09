using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public List<Powerup> powerups;
    private List<Powerup> powerupRemoveQueue;
    // Start is called before the first frame update
    void Start()
    {
        powerups = new List<Powerup>();
        powerupRemoveQueue = new List<Powerup>();
    }

    // Update is called once per frame
    void Update()
    {
        DecrementPowerupTimers();
    }
    //The Add() will eventually add the powerup
    public void Add(Powerup powerupToAdd)
    {
        powerupToAdd.Apply(this);
        powerups.Add(powerupToAdd);
    }
    //the Remove () will eventually remove the powerup
    public void Remove(Powerup powerupTORemove)
    {
        powerupTORemove.Remove(this);
        powerupRemoveQueue.Add(powerupTORemove);
    }
    public void DecrementPowerupTimers()
    {
        //One at atime, put each object in "powerups" into the variable 'powerup" and do the loop body on it
        foreach (Powerup powerup in powerups)
        {
            //subtract the time it took to draw the frame from one duration
            powerup.duration -= Time.deltaTime;
            if(powerup.duration <= 0)
            {
                Remove(powerup);
            }
        }
    }
    private void ApplyPowerupRemoveQueue()
    {
        //Now that we arent going through an active list, remove the powerups that are added to this list
        foreach(Powerup powerup in powerupRemoveQueue)
        {
            powerups.Remove(powerup);
        }
        //Reset the list
        powerupRemoveQueue.Clear();
    }
    private void LateUpdate()
    {
        ApplyPowerupRemoveQueue();
    }
}
