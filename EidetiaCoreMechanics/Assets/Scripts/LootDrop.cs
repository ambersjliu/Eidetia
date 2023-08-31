using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    
    private Transform enemyPosition;
    [SerializeField] private GameObject healthPack;
    [SerializeField] private GameObject battery;
    // Start is called before the first frame update
    void Start()
    {
        enemyPosition = transform;  
    }

    public void dropLoot()
    {
        int choice = (int)(transform.position.x % 2);
        GameObject loot = choice == 0 ? healthPack : battery;
        Instantiate(loot, enemyPosition.position, Quaternion.identity);
    }
}
