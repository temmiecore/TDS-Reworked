using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFloor : MonoBehaviour
{
    public IItemData data;

    void Update()
    {
        if (Vector2.Distance(GameManager.Instance.player.transform.position, transform.position) < 0.08f && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    public void PickUp()
    {
        if (data is IConsumableData consumable)
        {
            if (GameManager.Instance.inventory.OnPickUp(consumable))
            {
                GameManager.Instance.InstantiateFloatingText(data.name, Color.white, 1f, Random.Range(2, 5), transform);
                Destroy(gameObject);
            }
            else { GameManager.Instance.InstantiateFloatingText("Not enough space in my backpack.", Color.white, 1f, 1, transform); }
        }
        else if (data is IArtefactData artefact)
        {
            if (GameManager.Instance.inventory.OnPickUp(artefact))
            {
                GameManager.Instance.InstantiateFloatingText(data.name, Color.magenta, 1f, Random.Range(2, 5), transform);
                Destroy(gameObject);
            }
            else { GameManager.Instance.InstantiateFloatingText("Not enough space in my backpack.", Color.white, 1f, 1, transform); }
        }
    }
}
