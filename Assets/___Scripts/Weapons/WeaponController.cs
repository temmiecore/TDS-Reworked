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

        if (data is MeleeWeaponData)
            animator.SetTrigger("Attack");
        else if (data is RangeWeaponData rangeData)
        {
            rangeData.InstantiateProjectile(transform.position,
                                            GameManager.Instance.playerMover.handToMouseRotation - 90f,
                                            GameManager.Instance.playerMover.handToMouseDirection, ProjectileType.playerShot);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /// TODO: add push to attacks
        /// Perhaps make so that everyone can hurt everything with a Health() component? So enemies can kill each other, etc.
        if (data == null)
            return;

        if (data is MeleeWeaponData)
        {
            if (collision.tag == "Enemy" || collision.tag == "Destructable")
            {
                collision.GetComponent<Health>().RecieveDamage(data.damage + GameManager.Instance.player.additionalDamage);
                OnDamageDealt?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}