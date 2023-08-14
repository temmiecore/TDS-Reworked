using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeaponData : ScriptableObject
{
    public float damage;
    public float attackSpeed;
    public Sprite sprite;

    public GameObject prefabReference;

    public int requiredStrength;
    public int requiredDexterity;
    public int requiredIntelligence;

    public abstract void Drop();
}
