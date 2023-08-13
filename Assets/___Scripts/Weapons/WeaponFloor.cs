using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFloor : MonoBehaviour
{
    public IWeaponData data;

    void Update()
    {
        if (Vector2.Distance(GameManager.Instance.player.transform.position, transform.position) < 0.08f && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    public void PickUp()
    {
        GameManager.Instance.playerWeaponController.OnPickUp(data);
        Destroy(gameObject);
    }
}
