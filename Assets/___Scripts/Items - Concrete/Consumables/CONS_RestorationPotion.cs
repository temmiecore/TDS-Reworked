using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Restoration Potion", menuName = "Items/Consumables/Restoration Potion")]
public class CONS_RestorationPotion : IConsumableData
{
    public float hpAmount;

    public override void Drop()
    {
        Instantiate(GameManager.Instance.consumablePrefabs[0], GameManager.Instance.player.transform.position, GameManager.Instance.player.transform.rotation);

    }

    public override void Use()
    {
        GameManager.Instance.playerHealthComponent.Heal(hpAmount);
    }
}
