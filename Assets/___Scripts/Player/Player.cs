using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player: MonoBehaviour
{
    /// PlayerMover properties
    public Transform hand;
    public float handLength;

    public float additionalDamage;

    void Start()
    {

    }

    void Update()
    {
        
    }
}


public enum PlayerClass
{
    Knight,
    Archer,
    Mage,
    /// ...
}