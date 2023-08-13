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

    public void RecieveDamage(float damageAmount)
    {
        if (immunityDelay > immunityCooldown && isDamageable)
        {
            immunityDelay = 0f;

            HP -= damageAmount;

            GameManager.Instance.InstantiateFloatingText("-" + damageAmount, Color.red, 1f, Random.Range(2, 5), transform);

            animator?.SetTrigger("RecieveDamage");

            if (HP <= 0)
            { HP = 0; Die(); }
        }
    }

    public void Die()
    {
        /// TODO: Create a component that will drop stuff on Enemies' death. Or explode them, I don't know. 

        lives--;
        if (lives <= 0)
            Destroy(gameObject);
        else
        {
            GameManager.Instance.InstantiateFloatingText("Ankh Shard broken!", Color.green, 1f, Random.Range(2, 5), transform);
            HP = maxHP;
        }
    }

    public void Heal(float healAmount)
    {
        HP += healAmount;

        if (HP > maxHP)
            HP = maxHP;
    }
}
