using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellChangeController : MonoBehaviour
{
    private int GetCurrentSpellId()
    {
        return GameManager.Instance.inventory.spells.FindIndex(spell => spell = GameManager.Instance.inventory.currentSpell);
    }

    public void ChangeSpellUp()
    {
        int nextSpellId = GetCurrentSpellId() + 1;
        if (nextSpellId >= GameManager.Instance.inventory.spells.Count)
            nextSpellId = 0;

        GameManager.Instance.inventory.currentSpell = GameManager.Instance.inventory.spells[nextSpellId];
    }

    public void ChangeSpellDown()
    {
        int nextSpellId = GetCurrentSpellId() - 1;
        if (nextSpellId < 0 )
            nextSpellId = GameManager.Instance.inventory.spells.Count - 1;

        GameManager.Instance.inventory.currentSpell = GameManager.Instance.inventory.spells[nextSpellId];
    }
}
