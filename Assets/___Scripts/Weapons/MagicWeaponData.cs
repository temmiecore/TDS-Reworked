using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Serializable object class used for magic catalysts - staffs, wands, etc.
/// </summary>
[CreateAssetMenu(fileName = "Melee Weapon SO", menuName = "Weapons/Magic Weapon")]
public class MagicWeaponData : IWeaponData
{
    public override void Drop()
    {
        Instantiate(prefabReference, GameManager.Instance.player.transform.position, GameManager.Instance.player.transform.rotation);
    }

    public void UseCurrentSpell()
    {
        if (GameManager.Instance.player.mana < GameManager.Instance.inventory.currentSpell.manaUsage)
            return;

        if (GameManager.Instance.inventory.currentSpell.requiredIntelligence > GameManager.Instance.player.intelligence)
            return;

        GameManager.Instance.inventory.currentSpell.UseSpell();
        GameManager.Instance.player.UseMana(GameManager.Instance.inventory.currentSpell.manaUsage);
    }
}
