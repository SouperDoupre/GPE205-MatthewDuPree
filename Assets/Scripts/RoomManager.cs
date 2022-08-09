using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] mazePrefabs;
    public int rows;
    public int columns;
    public float mazeWidth = 50;
    public float mazeHeight = 50;
    public int mapSeed;
    private Room[,] maze;
    public bool MapOfTheDay;

    // Start is called before the first frame update
    [Obsolete]
    void Start()
    {
        UnityEngine.Random.seed = mapSeed;
        GenerateMap();
        if (MapOfTheDay)
        {
            mapSeed = DateToInt(DateTime.Now.Date);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Returns a random room
    public GameObject RandomRoomPrefab()
    {
        return mazePrefabs[UnityEngine.Random.Range(0, mazePrefabs.Length)];
    }
    public int DateToInt(DateTime dateToUse)
    {
        //add our date up and return it
        return dateToUse.Year + dateToUse.Month + dateToUse.Day + dateToUse.Hour + dateToUse.Minute + dateToUse.Second + dateToUse.Millisecond;
    }

    [Obsolete]
    public void GenerateMap()
    {
        mapSeed = (int)UnityEngine.Random.value;
        //Clear out the grid - "column" is our X, "row" is our Y
        maze = new Room[columns, rows];

        //For each grid row..
        for(int currentRow = 0; currentRow < rows; currentRow++)
        {
            //Set our seed
            
            //for each column in that row
            for (int currentCol = 0; currentCol < columns; currentCol++)
            {
                //figure out the location
                float xPosition = mazeWidth * currentCol;
                float zPosition = mazeHeight * currentRow;
                Vector3 newPosition = new Vector3(xPosition, 0.0f, zPosition);

                //Create a new grid at the appropriate location
                GameObject tempRoomObject = Instantiate(RandomRoomPrefab(), newPosition, Quaternion.identity) as GameObject;

                //Set its parent
                tempRoomObject.transform.parent = this.transform;

                //Give it a meanigful name
                tempRoomObject.name = "Room_" + currentCol + "," + currentRow;

                //Get the room object
                Room tempRoom = tempRoomObject.GetComponent<Room>();

                //Save it to the grid array
                maze[currentCol, currentRow] = tempRoom;

                //Open doors
                //If we are on the bottom row, open the north door
                if(currentRow == 0)
                {
                    tempRoom.doorNorth.SetActive(false);
                }
                else if(currentRow == rows - 1)
                {
                    //otherwise, if we are on the top row, open the south door
                    Destroy(tempRoom.doorSouth);
                }
                else
                {
                    //Otherwise, we are in the middle, so open both doors
                    Destroy(tempRoom.doorNorth);
                    Destroy(tempRoom.doorSouth);
                }
                if(currentCol == 0)
                {
                    tempRoom.doorEast.SetActive(false);
                }
                else if(currentCol == columns - 1)
                {
                    Destroy(tempRoom.doorWest);
                }
                else
                {
                    Destroy(tempRoom.doorEast);
                    Destroy(tempRoom.doorWest);
                }
            }
        }
    }
}
