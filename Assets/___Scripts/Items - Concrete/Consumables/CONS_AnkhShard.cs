using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ankh Shard", menuName = "Items/Consumables/Ankh Shard")]
public class CONS_AnkhShard : IConsumableData
{
    public int lives;

    public override void Drop()
    {
        Instantiate(GameManager.Instance.consumablePrefabs[2], GameManager.Instance.player.transform.position, GameManager.Instance.player.transform.rotation);
    }

    public override void Use()
    {
        GameManager.Instance.playerHealthComponent.lives += lives;
    }
}
