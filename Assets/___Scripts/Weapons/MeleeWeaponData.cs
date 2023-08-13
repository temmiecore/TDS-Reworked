using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Melee Weapon SO", menuName = "Weapons/Melee Weapon")]
public class MeleeWeaponData : IWeaponData
{
    public RuntimeAnimatorController animationController;
    public Vector2 colliderOffcet;
    public Vector2 colliderSize;

    public override void Drop()
    {
        Instantiate(prefabReference, GameManager.Instance.player.transform.position, GameManager.Instance.player.transform.rotation);
    }
}
