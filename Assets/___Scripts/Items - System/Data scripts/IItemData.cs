using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IItemData : ScriptableObject
{
    public Sprite sprite;

    public abstract void Drop();
}
