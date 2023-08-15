using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Melee Weapon SO", menuName = "Weapons/Spells/Fireball")]
public class Spell_Fireball : ISpellData
{
    public GameObject fireballPrefab;
    public float fireballSpeed;
    public float fireballDamage;

    public void InstantiateFireBall()
    {
        Debug.Log("damn");
        GameObject projectile = Instantiate(fireballPrefab, GameManager.Instance.player.hand.transform.position, Quaternion.AngleAxis(GameManager.Instance.playerMover.handToMouseRotation - 90f, Vector3.forward));

        Projectile script = projectile.GetComponent<Projectile>();
        script.damage = fireballDamage;
        script.type = ProjectileType.playerShot;

        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.AddForce(GameManager.Instance.playerMover.handToMouseDirection.normalized * fireballSpeed);
    }

    public override void UseSpell()
    {
        InstantiateFireBall();
    }
}
