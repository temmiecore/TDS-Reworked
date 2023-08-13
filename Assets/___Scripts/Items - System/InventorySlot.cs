using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public int id;
    public byte type;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!GameManager.Instance.inventory.isActive)
            return;

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (type == 0)
                GameManager.Instance.inventory.OnConsumableUse(id);
            return;
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            GameManager.Instance.inventory.OnDrop(type, id);
            return;
        }
    }
}