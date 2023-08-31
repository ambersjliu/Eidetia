using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    Enemy enemy;

    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("player"))
        {
            enemy.playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("player"))
        {
            enemy.playerInRange = false;
        }
    }
}
