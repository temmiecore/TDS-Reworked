using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator), typeof(BoxCollider2D))]
public class NPCWeaponController : MonoBehaviour
{
    private Animator animator;

    public IWeaponData data;
    public BTreeController tree;

    private void Start()
    {
        animator = GetComponent<Animator>();

        GetComponent<SpriteRenderer>().sprite = data.sprite;

        if (data is MeleeWeaponData meleeData)
        {
            animator.runtimeAnimatorController = meleeData.animationController;
            animator.enabled = true;
            GetComponent<BoxCollider2D>().offset = meleeData.colliderOffcet;
            GetComponent<BoxCollider2D>().size = meleeData.colliderSize;
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void Attack()
    {
        if (data == null)
            return;

        try
        {
            if (data is MeleeWeaponData)
                animator.SetTrigger("Attack");
            else if (data is RangeWeaponData rangeData)
            {
                Vector2 direction = tree.target.position - transform.position;
                float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


                rangeData.InstantiateProjectile(transform.position,
                                                rotation - 90f,
                                                direction, ProjectileType.enemyShot);
            }
        }
        catch { }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (data == null)
            return;

        if (!tree.isFriendly && (collision.tag == "Player" || collision.GetComponent<BTreeController>()?.isFriendly == !tree.isFriendly))
            collision.GetComponent<Health>()?.RecieveDamage(data.damage);
        else if (tree.isFriendly && collision.GetComponent<BTreeController>()?.isFriendly == !tree.isFriendly)
            collision.GetComponent<Health>()?.RecieveDamage(data.damage);
    }
}
