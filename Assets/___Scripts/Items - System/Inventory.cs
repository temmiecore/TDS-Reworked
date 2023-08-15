using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [HideInInspector] public CanvasGroup canvasGroup;

    public List<IConsumableData> consumables;
    public List<IArtefactData> artefacts;
    public List<ISpellData> spells;
    public ISpellData currentSpell;

    [HideInInspector] public bool isActive;

    [Header("Item Cells")]
    public Image[] consumableCells;
    public Image[] artefactCells;
    public Image[] spellCells;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        isActive = false;
        canvasGroup.alpha = 0f;
    }

    public void ResetInventory()
    {
        foreach (Image cell in consumableCells)
            cell.sprite = null;

        foreach (Image cell in artefactCells)
            cell.sprite = null;
    }

    public void UpdateInventory()
    {
        ResetInventory();

        int i = 0;

        foreach (IConsumableData item in consumables)
        { consumableCells[i].sprite = item.sprite; i++; }

        i = 0;

        foreach (IArtefactData item in artefacts)
        { artefactCells[i].sprite = item.sprite; i++; }
    }

    public void OnPickUp(IConsumableData item)
    {
        consumables.Add(item);

        UpdateInventory();
    }

    public void OnPickUp(IArtefactData item)
    {
        artefacts.Add(item);
        item.Activate();

        UpdateInventory();
    }

    public void OnDrop(byte itemType, int cellId) /// 0 - Consumable, 1 - Artefact
    {
        if (itemType == 0)
        {
            consumables[cellId].Drop();
            consumables.RemoveAt(cellId);
        }
        else if (itemType == 1)
        {
            artefacts[cellId].Deactivate();
            artefacts[cellId].Drop();
            artefacts.RemoveAt(cellId);
        }

        UpdateInventory();
    }

    public void OnConsumableUse(int cellId)
    {
        consumables[cellId].Use();
        consumables.RemoveAt(cellId);

        UpdateInventory();
    }

    public void OnArtefactActivate(int cellId)
    {
        artefacts[cellId].Activate();

        UpdateInventory();
    }

    public void ToggleInventory()
    {
        if (canvasGroup.alpha == 0f)
        { isActive = true; canvasGroup.alpha = 1f; }
        else
        { isActive = false; canvasGroup.alpha = 0f; }
    }
}
