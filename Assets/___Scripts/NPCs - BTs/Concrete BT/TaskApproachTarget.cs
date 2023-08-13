using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TaskApproachTarget: Node
{

    public TaskApproachTarget(BTreeController tree)
    {
        this.tree = tree;
    }

    public override NodeState Execute()
    {
        Transform targetPosition = (Transform)GetData("target");

        tree.pathfinder.destination = targetPosition.position;

        if (tree.enemyTransform.position.x - tree.pathfinder.destination.x > 0)
            tree.spriteRenderer.flipX = true;
        else
            tree.spriteRenderer.flipX = false;

        state = NodeState.RUNNING;
        return state;
    }
}
