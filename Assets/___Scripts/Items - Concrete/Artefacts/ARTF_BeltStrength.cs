using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Belt of Strength", menuName = "Items/Artefacts/Belt of Strength")]
public class ARTF_BeltStrength : IArtefactData
{
    public override void Activate()
    {
        GameManager.Instance.player.additionalDamage += 3f;
    }

    public override void Deactivate()
    {
        GameManager.Instance.player.additionalDamage -= 3f;
    }

    public override void Drop()
    {
        Instantiate(GameManager.Instance.artefactPrefabs[0], GameManager.Instance.player.transform.position, GameManager.Instance.player.transform.rotation);
    }
}
