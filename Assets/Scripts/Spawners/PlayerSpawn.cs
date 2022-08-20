using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
<<<<<<< HEAD
    GameManager gameManager;
    public float PlaceX;
    public float PlaceZ;
    RoomManager room;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        PlaceX = Random.Range(0, room.columns + 1);
        PlaceZ = Random.Range(0, room.rows + 1);
        gameManager.playerSpawnTransform.transform.position = new Vector3(PlaceX, 0, PlaceX);
=======
    // Start is called before the first frame update
    void Start()
    {
        
>>>>>>> main
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
