using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Transform), typeof(AIPath), typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator), typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class BTreeController : Tree
{
    [HideInInspector] public Transform enemyTransform;
    [HideInInspector] public AIPath pathfinder;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Animator animator;
    [HideInInspector] public Rigidbody2D rigidbody;
    [HideInInspector] public CapsuleCollider2D capsuleCollider;

    public EnemyWeaponController enemyWeapon;
    public Transform enemyHand;
    public BehaviourTreeType behaviourTreeType;
    public string targetTag;

    public float alertRadius;
    public float ignoreRadius;
    public float attackRadius;
    public float attackCooldown;

    [HideInInspector] public bool isAlerted;
    [HideInInspector] public Transform target;

    protected override void Start()
    {
        enemyTransform = GetComponent<Transform>();
        pathfinder = GetComponent<AIPath>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();

        base.Start();
    }

    protected override Node SetupTree()
    {
        return GameManager.Instance.behaviourTreeManager.SetupTree(behaviourTreeType, this);
    }
}

public enum BehaviourTreeType
{
    WanderingCircle,
    Wandering,
    Patrol,
}