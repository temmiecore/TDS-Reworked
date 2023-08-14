using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Class", menuName = "Player Class")]
public class PlayerClass : ScriptableObject
{
    [Header("Parameters")]
    public int vitality;
    public int strength;
    public int wisdom;
    public int dexterity;
    public int intelligence;

    public RuntimeAnimatorController animatorController;
}
