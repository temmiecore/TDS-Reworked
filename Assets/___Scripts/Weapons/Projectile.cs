using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector] public float damage;
    [HideInInspector] public ProjectileType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Health>()?.RecieveDamage(damage); 
        Destroy(gameObject);
    }
}
