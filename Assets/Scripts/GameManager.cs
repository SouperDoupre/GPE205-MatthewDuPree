using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //PlayerSpawn Point
    public Transform playerSpawnTransform;
    //List of players
    public List<PlayerController> players;
    public List<AIController> Enemies;
    public List<RoomManager> maps;
    RoomManager roomManager;
    // Game States
    public GameObject TitleScreenStateObject;
    public GameObject PauseStateObject;
    public GameObject OptionsScreenStateObject;
    public GameObject CreditsScreenStateObject;
    public GameObject GameplayStateObject;
    public GameObject GameOverScreenStateObject;
    PlayerController playerController;
    AudioSource ambient;
    //States of the game
    public enum GameStates { TitleScreen, Gameplay, OptionsScreen, PauseMenu, GameOver, Credits, Quit }
    public GameStates currentState;
    private float lastStateChangeTime;
    public Camera overlayCam;
    private void Awake()
    {
        //If the instance doesn't exist yet...
        if (instance == null)
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
        ambient = GetComponent<AudioSource>();
        playerController = GetComponent<PlayerController>();
        roomManager = GetComponent<RoomManager>();
        ActivateTitleScreen();
    }
    public void Update()
    {
        ChangeState(currentState);
        ChangingMenus();
        if (currentState != GameStates.Gameplay)
        {
            ambient.Pause();
        }

    }
    public void ChangeState(GameStates newState)
    {
        //Change the current state
        currentState = newState;
        //Save the time when we changed states
        lastStateChangeTime = Time.time;
    }
    public void SpawnPlayer()
    {
        //Spawns PC at 0,0,0 with no rotation
        GameObject newPlayerObj = Instantiate(PCPreFab, Vector3.zero, Quaternion.identity) as GameObject;

        //Spawn the Pawn and connect it to the controller
        GameObject newPawnObj = Instantiate(TPPreFab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;

        //Get the PlayerController component and Pawn component
        PlayerController newController = newPlayerObj.GetComponent<PlayerController>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();
        //Hook them up
        newController.pawn = newPawn;
        newPawn.controller = newController;
    }

    //Prefabs
    public GameObject PCPreFab;
    public GameObject TPPreFab;

    private void DeactivateAllStates()
    {
        //Deactivate all Game States
        TitleScreenStateObject.SetActive(false);
        PauseStateObject.SetActive(false);
        GameplayStateObject.SetActive(false);
        OptionsScreenStateObject.SetActive(false);
        GameOverScreenStateObject.SetActive(false);
        CreditsScreenStateObject.SetActive(false);
    }
    public GameObject AMPreFab;
    public void ActivateTitleScreen()
    {
        //Deactivate all game states
        DeactivateAllStates();
        //Activate title screen
        TitleScreenStateObject.SetActive(true);
        ChangeState(GameStates.TitleScreen);
        Time.timeScale = 0f;
    }
    public void ActivatePauseMenu()
    {
        DeactivateAllStates();
        PauseStateObject.SetActive(true);
        ChangeState(GameStates.PauseMenu);
    }
    public void ActivateGameplay()
    {
        DeactivateAllStates();
        GameplayStateObject.SetActive(true);
        ChangeState(GameStates.Gameplay);
        Time.timeScale = 1f;
    }
    public void ActivateOptionsScreen()
    {
        DeactivateAllStates();
        OptionsScreenStateObject.SetActive(true);
        ChangeState(GameStates.OptionsScreen);
        Time.timeScale = 0f;
    }
    public void ActivateGameOverScreen()
    {
        DeactivateAllStates();
        GameOverScreenStateObject.SetActive(true);
        ChangeState(GameStates.GameOver);
        Time.timeScale = 0f;
    }
    public void ActivateCreditsScreen()
    {
        DeactivateAllStates();
        CreditsScreenStateObject.SetActive(true);
        ChangeState(GameStates.Credits);
        Time.timeScale = 0f;
    }

    public void GameStart()
    {        
        if (players.Count == 0)
        {
            SpawnPlayer();
            ChangeState(GameStates.Gameplay);
            ambient.Play();
            roomManager.GenerateMap(roomManager.mapSeed);
        }
        else
        {
            ChangeState(GameStates.Gameplay);
            ambient.Play();
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        ambient.UnPause();
        ChangeState(GameStates.Gameplay);
    }
    public void ChangingMenus()
    {
        switch (currentState)
        {

            case GameStates.TitleScreen:
                ActivateTitleScreen();
                Time.timeScale = 0f;
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    if (players.Count > 0)
                    {
                        ResumeGame();
                    }
                    else
                    {
                        GameStart();
                    }
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    ChangeState(GameStates.OptionsScreen);
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                    ChangeState(GameStates.PauseMenu);
                }
                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    ChangeState(GameStates.GameOver);
                }
                if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    ChangeState(GameStates.Credits);
                }
                if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    ChangeState(GameStates.Quit);
                }
                break;
            case GameStates.Gameplay:
                ActivateGameplay();
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    ChangeState(GameStates.OptionsScreen);
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                    ChangeState(GameStates.PauseMenu);
                }
                if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    ChangeState(GameStates.Credits);
                }
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    ChangeState(GameStates.TitleScreen);
                }
                if(Input.GetKeyDown(KeyCode.Alpha5))
                {
                    ChangeState(GameStates.GameOver);
                }
                break;
            case GameStates.OptionsScreen:
                ActivateOptionsScreen();
                Time.timeScale = 0f;
                if (Input.GetKeyDown(KeyCode.P))
                {
                    ChangeState(GameStates.PauseMenu);
                }
                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    ChangeState(GameStates.GameOver);
                }
                if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    ChangeState(GameStates.Credits);
                }
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    ChangeState(GameStates.TitleScreen);
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    ResumeGame();
                }
                break;
            case GameStates.PauseMenu:
                ActivatePauseMenu();
                Time.timeScale = 0f;
                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    ChangeState(GameStates.GameOver);
                }
                if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    ChangeState(GameStates.Credits);
                }
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    ChangeState(GameStates.TitleScreen);
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    ResumeGame();
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    ChangeState(GameStates.OptionsScreen);
                }
                break;
            case GameStates.GameOver:
                ActivateGameOverScreen();
                Time.timeScale = 0f;
                if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    ChangeState(GameStates.Credits);
                }
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    ChangeState(GameStates.TitleScreen);
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    ResumeGame();
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    ChangeState(GameStates.OptionsScreen);
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                    ChangeState(GameStates.PauseMenu);
                }
                break;
            case GameStates.Credits:
                ActivateCreditsScreen();
                Time.timeScale = 0f;
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    ChangeState(GameStates.TitleScreen);
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    ResumeGame();
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    ChangeState(GameStates.OptionsScreen);
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                    ChangeState(GameStates.PauseMenu);
                }
                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    ChangeState(GameStates.GameOver);
                }
                break;
            case GameStates.Quit:
                QuitGame();
                Time.timeScale = 0f;
                break;
        }
    }
}
