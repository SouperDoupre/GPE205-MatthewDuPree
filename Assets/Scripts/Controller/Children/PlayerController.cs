using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Controller
{
    public KeyCode moveForewardKey;
    public KeyCode moveBackwardKey;
    public KeyCode lookRightKey;
    public KeyCode lookLeftKey;
    public KeyCode shootKey;
    public float startingLives;
    public float currentLives;
    public float score;
    public Text scoreTotal;
    public Text lives;
    float bonus;
    public const float bonusInterval = 10;
    // Start is called before the first frame update
    public override void Start()
    {
        score = 0;
        bonus += bonusInterval;
        currentLives = startingLives;

        //If theres a GameManager
        if(GameManager.instance != null)
        {
            //And it tracks players
            if(GameManager.instance.players != null)
            {
                //Add the player to it's list
                GameManager.instance.players.Add(this);
            }
        }
        //Runs data from parent class Controller in Start()
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        PlayerDied();
        if(lives != null)
        {
            lives.text = "Lives: " + currentLives;
        }
        if (scoreTotal != null)
        {
            scoreTotal.text = "Score: " + score;
        }
        base.Update();
        if(score >= bonus)
        {
            currentLives += 1;
            bonus += bonusInterval;
        }
    }
    public void DecreaseLives(Pawn pawn)
    {
        currentLives = startingLives - 1;
    }
    public void OnDestroy()
    {
        //If theres a GameManager
        if (GameManager.instance != null)
        {
            //And it tracks players
            if (GameManager.instance.players != null)
            {
                //Take it off the list
                GameManager.instance.players.Remove(this);
            }
        }
    }

    public override void ProccessInputs()
    {
        if (Input.GetKey(moveForewardKey))
        {
            pawn.Moveforward();
        }
        
        if (Input.GetKey(moveBackwardKey))
        {
            pawn.Movebackward();
        }
        
        if (Input.GetKey(lookRightKey))
        {
            pawn.LookRight();
        }

        if (Input.GetKey(lookLeftKey))
        {
            pawn.LookLeft();
        }
        
        if (Input.GetKeyDown(shootKey))
        {
            
            pawn.Shoot();
        }
    }
    public void AddScore(float amount)
    {
        score = score + amount;

    }
    public void PlayerDied()
    {
        if(pawn == null)
        {
            DecreaseLives(pawn);
            if(currentLives > 0)
            {
                Destroy(gameObject);
                FindObjectOfType<GameManager>().SpawnPlayer();
            }
        }
    }
}
