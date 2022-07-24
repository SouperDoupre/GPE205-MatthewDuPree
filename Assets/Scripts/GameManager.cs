using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //PlayerSpawn Point
    public Transform playerSpawnTransform;
    private void Awake()
    {
        //If the instance doesn't exist yet...
        if(instance == null)
        {
            //This is the instance
            instance = this;
            //Don't destroy it if we load a new scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Otherwise, destroy the extra gameObject
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        SpawnPlayer();
    }
    public void SpawnPlayer()
    {
        //Spawns PC at 0,0,0 with no rotation
        GameObject newPlayerObj = Instantiate(PCPreFab, Vector3.zero, Quaternion.identity) as GameObject;
        
        //Spawn the Pawn and connect it to the controller
        GameObject newPawnObj = Instantiate(TPPreFab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;
        
        //Get the PlayerController component and Pawn component
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();
        //Hook them up
        newController.pawn = newPawn;
    }
    //Prefabs
    public GameObject PCPreFab;
    public GameObject TPPreFab;

}
