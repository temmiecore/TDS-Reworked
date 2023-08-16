using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Serializable object class used for magic spells, used by magic catalysts.
/// </summary>
public abstract class ISpellData : ScriptableObject
{
    public abstract void UseSpell();

    public float manaUsage;
    public int requiredIntelligence;

    public Sprite UiIcon;
}
