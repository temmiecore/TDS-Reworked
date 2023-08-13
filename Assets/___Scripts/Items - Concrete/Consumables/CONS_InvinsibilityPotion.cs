using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Invinsibility Potion", menuName = "Items/Consumables/Invinsibility Potion")]
public class CONS_InvinsibilityPotion : IConsumableData
{
    public float invinsibilityTime;

    public override void Drop()
    {
        Instantiate(GameManager.Instance.consumablePrefabs[1], GameManager.Instance.player.transform.position, GameManager.Instance.player.transform.rotation);
    }

    public override void Use()
    {
        GameManager.Instance.itemUseController.InvinsibilityPotion(invinsibilityTime);
    }
}
