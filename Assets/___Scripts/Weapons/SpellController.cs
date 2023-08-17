using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellController : MonoBehaviour
{
    [HideInInspector] public CanvasGroup canvasGroup;
    [HideInInspector] public bool isActive;

    public List<ISpellData> spells;
    public ISpellData currentSpell;
    public int currentSpellId;

    public List<Image> spellCells;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        isActive = false;
        canvasGroup.alpha = 0f;

        canvasGroup.blocksRaycasts = false;
    }

    public void ToggleWindow()
    {
        if (canvasGroup.alpha == 0f)
        {
            isActive = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
            UpdateWindow();
        }
        else
        {
            isActive = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0f;
        }
    }

    private void UpdateWindow()
    {
        for (int i = 0; i < spells.Count; i++)
        {
            spellCells[i].sprite = spells[i].UiIcon;
            //spellCells[i].SetNativeSize();
        }
    }

    public void ChangeSpell()
    {
        if (spells.Count == 0)
            return;

        int nextSpellId = currentSpellId + 1;
        if (nextSpellId > spells.Count - 1)
            nextSpellId = 0;

        currentSpell = spells[nextSpellId];
        currentSpellId = nextSpellId;
    }

    public void OnSpellPickUp(ISpellData spell)
    {
        spells.Add(spell);

        if (spells.Count == 1)
        {
            currentSpell = spell;
            currentSpellId = 0;
        }
    }
}
