using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Transform), typeof(AIPath), typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator), typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class BTreeController : Tree
{
    [HideInInspector] public Transform npcTransform;
    [HideInInspector] public AIPath pathfinder;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Animator animator;
    [HideInInspector] public Rigidbody2D rigidbody;
    [HideInInspector] public CapsuleCollider2D capsuleCollider;

    public NPCWeaponController enemyWeapon;
    public Transform enemyHand;
    public BehaviourTreeType behaviourTreeType;
    public bool isFriendly;

    public float alertRadius;
    public float ignoreRadius;
    public float attackRadius;
    public float attackCooldown;

    [Header("- For NPC/Enemies who follow something. -")]
    public Transform followTarget;
    public float followRadius;

    [Header("TARGET")]
    [HideInInspector] public bool isAlerted;
    public Transform target;
    [HideInInspector] public float aggression; /// For target changing

    protected override void Start()
    {
        npcTransform = GetComponent<Transform>();
        pathfinder = GetComponent<AIPath>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        target = null;

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