using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Range Weapon SO", menuName = "Weapons/Range Weapon")]
public class RangeWeaponData : IWeaponData
{
    public float projectileSpeed;
    public GameObject projectilePrefab;

    public override void Drop()
    {
        Instantiate(prefabReference, GameManager.Instance.player.transform.position, GameManager.Instance.player.transform.rotation);
    }

    public void InstantiateProjectile(Vector3 position, float rotationAngle, Vector2 direction, ProjectileType type)
    {
        GameObject projectile = Instantiate(projectilePrefab, position, Quaternion.AngleAxis(rotationAngle, Vector3.forward));

        //projectile.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);

        Projectile script = projectile.GetComponent<Projectile>();
        script.damage = this.damage;
        script.type = type;

        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.AddForce(direction.normalized * projectileSpeed);
    }
}

public enum ProjectileType
{
    playerShot,
    enemyShot,
    npcShot
}