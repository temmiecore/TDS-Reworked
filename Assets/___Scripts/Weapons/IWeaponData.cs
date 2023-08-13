using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeaponData : ScriptableObject
{
    public float damage;
    public float attackSpeed;
    public Sprite sprite;

    public GameObject prefabReference;

    public abstract void Drop();
}
