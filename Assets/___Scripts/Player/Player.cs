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
    public int mana;

    private float manaDelay;

    [Header("Player parameters")]
    public int vitality;
    public int strength;
    public int wisdom;
    public int dexterity;
    public int intelligence;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void ManaRestoration()
    {
        manaDelay += Time.deltaTime;

        if (manaDelay > 1f)
        {
            manaDelay = 0f;
            mana += 1;
        }

        if (mana > maxMana)
            mana = maxMana;
    }
}