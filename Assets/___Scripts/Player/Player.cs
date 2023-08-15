using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player: MonoBehaviour
{
    [Header("PlayerMover properties")]
    public Transform hand;
    public float handLength;

    [HideInInspector] public float additionalDamage;

    [Header("Mana")]
    public int maxMana;
    public float mana;
    [HideInInspector] public bool manaWasUsed;
    public float manaRestorationSpeed;

    [Header("Player parameters")]
    public int vitality;
    public int strength;
    public int wisdom;
    public int dexterity;
    public int intelligence;

    [Header("Level parameters")]
    public int xp;

    public int level;
    public int levelingPoints;

    void Start()
    {
        mana = maxMana;
    }

    void Update()
    {
        ManaRestoration();
    }

    void ManaRestoration()
    {
        if (manaWasUsed)
        {
            StartCoroutine(ManaWasUsed());
            return;
        }

        mana += Time.deltaTime * manaRestorationSpeed; /// Make it faster? 

        if (mana > maxMana)
            mana = maxMana;
    }

    IEnumerator ManaWasUsed()
    {
        yield return new WaitForSeconds(1f);
        manaWasUsed = false;
    }

    internal void UseMana(float manaUsage)
    {
        mana -= manaUsage;
        manaWasUsed = true;

        if (mana < 0)
            mana = 0;
    }
}