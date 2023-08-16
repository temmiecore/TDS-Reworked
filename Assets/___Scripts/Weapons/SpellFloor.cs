using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFloor : MonoBehaviour
{
    public ISpellData data;

    void Update()
    {
        if (Vector2.Distance(GameManager.Instance.player.transform.position, transform.position) < 0.08f && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    public void PickUp()
    {
        GameManager.Instance.InstantiateFloatingText(name, Color.green, 1f, 1, transform);
        GameManager.Instance.spellController.OnSpellPickUp(data);
        Destroy(gameObject);
    }
}
