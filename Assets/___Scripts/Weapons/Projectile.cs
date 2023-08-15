using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector] public float damage;
    [HideInInspector] public ProjectileType type;

    [HideInInspector] public BTreeController tree;

    /// No need to use ProjectyleType anymore, but i'll let it stay
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (type == ProjectileType.playerShot && (collision.tag == "Enemy" || collision.tag == "Destructable"))
        { collision.GetComponent<Health>()?.RecieveDamage(damage); Destroy(gameObject); }
        else if (type == ProjectileType.enemyShot && (collision.tag == "Player" || collision.tag == "NPC"))
        { collision.GetComponent<Health>()?.RecieveDamage(damage, tree); Destroy(gameObject); }
        else if (type == ProjectileType.npcShot && collision.tag == "Enemy")
        { collision.GetComponent<Health>()?.RecieveDamage(damage, tree); Destroy(gameObject); }

        else if (collision.tag == "TerrainCol")
            Destroy(gameObject);
    }
}
