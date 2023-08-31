using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int amountToDamage;
    public float despawnTime = 3f;


    private void Start()
    {
        Destroy(gameObject, despawnTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall")
        {
            AudioController.instance.Play("Tomato");
            Destroy(gameObject);
        }

        if(other.TryGetComponent<Player>(out var player))
        {
            AudioController.instance.Play("Tomato");
            player.Damage(amountToDamage);
            GameUIUpdater.instance.updatePlayerHP(player.HP);
            Destroy(gameObject);
        }
        

    }



}
