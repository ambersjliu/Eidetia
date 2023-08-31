using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{

    public static MazeManager instance;
    public MazeState state;
    public bool doorCanOpen;
    public bool gameIsPaused;
    public Player player;

    // Start is called before the first frame update

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Reset()
    {
        updateMazeState(MazeState.minotaurNotFound);
        player.Reset();
        gameIsPaused = false; 
    }

    public void updateMazeState(MazeState newState)
    {
        state = newState;
        switch(newState)
        {
            case MazeState.minotaurNotFound:
                doorCanOpen = false;
                break;
            case MazeState.minotaurFound: 
                doorCanOpen = true;
                break;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum MazeState
{
    minotaurNotFound,
    minotaurFound,
}