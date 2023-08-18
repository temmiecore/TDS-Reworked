using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHP;
    public float HP;

    [HideInInspector] public bool isDamageable;
    [HideInInspector] public int lives;

    private float immunityDelay;
    private float immunityCooldown;

    private Animator animator;

    private Transform lastAttacker;

    void Start()
    {
        HP = maxHP;
        immunityCooldown = 0.4f;
        immunityDelay = 0f;
        isDamageable = true;
        lives = 1;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        immunityDelay += Time.deltaTime;
    }

    public void ReceiveDamage(float damageAmount, Transform attacker)
    {
        if (immunityDelay > immunityCooldown && isDamageable)
        {
            immunityDelay = 0f;

            HP -= damageAmount;

            GameManager.Instance.InstantiateFloatingText("-" + damageAmount, Color.red, 1f, Random.Range(2, 5), transform);

            animator?.SetTrigger("ReceiveDamage");

            lastAttacker = attacker;

            try { GetComponent<BTreeController>().AddThreat(attacker); } catch { }

            if (attacker.TryGetComponent(out Player playerComponent))
                playerComponent.OnDamageDealtHandler();

            if (HP <= 0)
            { HP = 0; Die(); }
        }
    }

    public void Die()
    {
        lives--;
        if (lives <= 0)
        {
            try { GetComponent<BTreeController>().OnDeath(lastAttacker); } catch { }
            /// Player death method
        }
        else
        {
            GameManager.Instance.InstantiateFloatingText("Ankh Shard broken!", Color.green, 1f, Random.Range(2, 5), transform);
            HP = maxHP;
        }
    }

    public void Heal(float healAmount)
    {
        GameManager.Instance.InstantiateFloatingText("+" + healAmount, Color.green, 1f, Random.Range(2, 5), transform);

        HP += healAmount;

        if (HP > maxHP)
            HP = maxHP;
    }
}
