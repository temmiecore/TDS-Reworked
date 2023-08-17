using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used for getting user input and using it
/// to invoke different player-related actions, other that movement.
/// </summary>
[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Attack();

        if (Input.GetKeyDown(KeyCode.Tab))
            OpenInventory();

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            ChangeSpell();

        if (Input.GetKeyDown(KeyCode.L))
            OpenLevelupWindow();

    }

    void Attack()
    {
        GameManager.Instance.playerWeaponController.Attack();
    }

    void OpenInventory()
    {
        GameManager.Instance.inventory.ToggleInventory();
    }

    void OpenLevelupWindow()
    {
        GameManager.Instance.levelupWindowController.ToggleWindow();
    }

    void ChangeSpell()
    {
        GameManager.Instance.spellController.ChangeSpell();
    }
    /// All future actions should be encapsulated in a function.
}
