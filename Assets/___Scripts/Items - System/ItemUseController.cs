using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class, responsible for usage of items with mechanics that require a 
/// Monobehaviour/Singleton to operate, for example coroutines. If an Item needs to
/// do a timed action, it needs to be represented as a method in this class.
/// </summary>
public class ItemUseController : MonoBehaviour
{
    public void InvinsibilityPotion(float time)
    {
        StartCoroutine(InvinsibilityCoroutine(time));
    }

    IEnumerator InvinsibilityCoroutine(float time)
    {
        GameManager.Instance.playerHealthComponent.isDamageable = false;
        yield return new WaitForSeconds(time);
        GameManager.Instance.playerHealthComponent.isDamageable = true;
    }
}
