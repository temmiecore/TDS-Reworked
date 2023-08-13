using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator), typeof(BoxCollider2D))]
public class EnemyWeaponController : MonoBehaviour
{
    private Animator animator;

    public IWeaponData data;

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

        if (data is MeleeWeaponData)
            animator.SetTrigger("Attack");
        else if (data is RangeWeaponData rangeData)
        {
            Vector2 direction = GameManager.Instance.player.transform.position - transform.position;
            float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


            rangeData.InstantiateProjectile(transform.position,
                                            rotation - 90f,
                                            direction, ProjectileType.enemyShot);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("damn");

        /// TODO: add push to attacks
        /// Perhaps make so that everyone can hurt everything with a Health() component? So enemies can kill each other accidentally. DONE
        if (data == null)
            return;

        if (data is MeleeWeaponData)
            collision.GetComponent<Health>()?.RecieveDamage(data.damage);
    }
}
