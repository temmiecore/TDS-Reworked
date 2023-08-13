using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskAttack : Node
{
    private float attackDelay = 0f;
    private Vector2 direction;

    public TaskAttack(BTreeController tree)
    {
        this.tree = tree;
    }

    public override NodeState Execute()
    {
        try
        {
            attackDelay += Time.deltaTime;

            if (attackDelay > tree.attackCooldown)
            {
                attackDelay = 0f;
                Attack();

                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.RUNNING;
            return state;
        }
        catch 
        {
            state = NodeState.FAILURE;
            return state;
        }
    }

    public virtual void Attack()
    {
        if (direction.x < 0)
            tree.spriteRenderer.flipX = true;
        else
            tree.spriteRenderer.flipX = false;

        tree.pathfinder.destination = tree.target.position;
        tree.enemyWeapon.Attack();
    }
}
