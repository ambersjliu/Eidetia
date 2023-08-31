using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState state;
    public static event Action<GameState> OnStateChange;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }


    private void Start()
    {
        UpdateGameState(GameState.startPage);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;
        switch (newState)
        {
            case GameState.startPage:
                Time.timeScale = 0f;
                break;
            case GameState.exploringMaze:
                MazeManager.instance.Reset();
                Time.timeScale = 1f;
                TimerController.instance.beginTimer();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
            case GameState.win:
                TimerController.instance.endTimer();
                Time.timeScale = 0f;
                CanvasManager.instance.SwitchCanvas(CanvasType.EndScreen);
                AudioController.instance.Play("Winning");
                Debug.Log("Win!");
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                break;
            case GameState.lose:
                TimerController.instance.endTimer();
                Time.timeScale = 0f;
                CanvasManager.instance.SwitchCanvas(CanvasType.EndScreen);
                GameUIUpdater.instance.endScreenLost();
                Debug.Log("Lose!");
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                break;
        }


        OnStateChange?.Invoke(state);
    }

    



}


public enum GameState
{
    startPage,
    exploringMaze,
    win,
    lose
}