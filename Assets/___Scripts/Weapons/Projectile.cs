using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector] public float damage;
    [HideInInspector] public ProjectileType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (type == ProjectileType.playerShot)
            if (collision.tag == "Enemy" || collision.tag == "Destructable")
            { collision.GetComponent<Health>().RecieveDamage(damage + GameManager.Instance.player.additionalDamage); Destroy(gameObject); }
        if (type == ProjectileType.enemyShot)
            if (collision.tag == "Player" || collision.tag == "NPC")
            { collision.GetComponent<Health>().RecieveDamage(damage); Destroy(gameObject); }

        if (collision.tag == "TerrainCol")
            Destroy(gameObject);
    }
}
