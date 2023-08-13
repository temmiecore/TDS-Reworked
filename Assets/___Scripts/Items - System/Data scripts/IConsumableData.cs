using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IConsumableData : IItemData
{
    public ConsumableType type;

    public abstract void Use();
}


/// Note - indexes in the enumerator should be the same as indexes in GameManager consumablePrefabs List
/// TODO: Add all remaining items to enum according to their indexing
public enum ConsumableType
{
    restorationPotion,
    invincibilityPotion,
    ankhShard,
    summoningTokenZombie,
    sacrificialSkull,
    scrollBerserk,

}