using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public int amountToHeal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            AudioController.instance.Play("Item");
            player.Heal(amountToHeal);
            GameUIUpdater.instance.updatePlayerHP(player.HP);
            Destroy(gameObject);
        }
    }


}
