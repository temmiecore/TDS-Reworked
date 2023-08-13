using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vampiric Tooth", menuName = "Items/Artefacts/Vampiric Tooth")]
public class ARTF_VampiricTooth : IArtefactData
{
    public override void Activate()
    {
        GameManager.Instance.playerWeaponController.OnDamageDealt += Vampirism;
    }

    public override void Deactivate()
    {
        GameManager.Instance.playerWeaponController.OnDamageDealt -= Vampirism;
    }

    public override void Drop()
    {
        Instantiate(GameManager.Instance.artefactPrefabs[1], GameManager.Instance.player.transform.position, GameManager.Instance.player.transform.rotation);
    }

    private void Vampirism(object sender, EventArgs args)
    {
        float healAmount = GameManager.Instance.playerWeaponController.data.damage / 3;
        GameManager.Instance.playerHealthComponent.Heal(healAmount);
    }
}
