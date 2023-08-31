using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{

    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayerHP();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InformOfDeath()
    {
        GameManager.Instance.UpdateGameState(GameState.lose);
        
    }

    public void UpdatePlayerHP()
    {
        GameUIUpdater.instance.updatePlayerHP(HP);
    }
}
