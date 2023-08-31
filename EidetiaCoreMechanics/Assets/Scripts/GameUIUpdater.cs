using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIUpdater : MonoBehaviour
{
    public TMP_Text endScreenText;
    public TMP_Text batteryText;
    public TMP_Text playerHP;
    public static GameUIUpdater instance;


    [SerializeField] private Player player;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateBatteryText(float maxBrightness, float currentIntensity)
    {
        if(batteryText == null)
        {
            return;
        }
        float floatPercent = currentIntensity / maxBrightness;
        int percent = (int) (floatPercent * 100);
        batteryText.text = "Battery: " + percent.ToString() + "%";
    }

    public void updatePlayerHP(int HP)
    {
        if(playerHP == null)
        {
            return;
        }
        playerHP.text = "HP: " + HP.ToString() + "%";
    }

    public void endScreenLost()
    {
        if(endScreenText == null)
        {
            return;
        }
        endScreenText.text = "Game over! Better luck next time!";
    }
}
