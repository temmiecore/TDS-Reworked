using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator), typeof(BoxCollider2D))]
public class WeaponController : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D collider;
    private SpriteRenderer spriteRenderer;

    public IWeaponData data;

    public event EventHandler OnDamageDealt;

    private void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnPickUp(IWeaponData data)
    {
        if (this.data == null)
        { this.data = data; }
        else
        { this.data.Drop(); this.data = data; }

        if (data is MeleeWeaponData meleeData)
        {
            animator.runtimeAnimatorController = meleeData.animationController;
            animator.enabled = true;
            collider.offset = meleeData.colliderOffcet;
            collider.size = meleeData.colliderSize;
            collider.enabled = true;
        }
        else
        {
            animator.runtimeAnimatorController = null;
            collider.enabled = false;
        }

        transform.localPosition = Vector3.zero;

        spriteRenderer.sprite = data.sprite;
    }

    public void Attack()
    {
        if (data == null)
            return;

        if (CheckParameters())
        {
            GameManager.Instance.InstantiateFloatingText("I'm not skilled enough to use this.", Color.white, 1f, 1, GameManager.Instance.player.transform);
            return;
        }

        if (data is MeleeWeaponData)
            animator.SetTrigger("Attack");
        else if (data is RangeWeaponData rangeData)
            rangeData.InstantiateProjectile(transform.position,
                GameManager.Instance.playerMover.handToMouseRotation - 90f,
                GameManager.Instance.playerMover.handToMouseDirection);
        else if (data is MagicWeaponData magicData)
            magicData.UseCurrentSpell();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /// TODO: add push to attacks
        if (data == null)
            return;

        if (collision.tag == "Enemy" || collision.tag == "Destructable")
        {
            collision.GetComponent<Health>()?.RecieveDamage(data.damage + GameManager.Instance.player.additionalDamage);
            OnDamageDealt?.Invoke(this, EventArgs.Empty);
        }
    }

    /// If required parameter is higher of player's parameter, weapon can't be used.
    private bool CheckParameters()
    {
        if (data.requiredStrength > GameManager.Instance.player.strength)
            return true;
        if (data.requiredDexterity > GameManager.Instance.player.dexterity)
            return true;
        if (data.requiredIntelligence > GameManager.Instance.player.intelligence)
            return true;

        return false;
    }
}