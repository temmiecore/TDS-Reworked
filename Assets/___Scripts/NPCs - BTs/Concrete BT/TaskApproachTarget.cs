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
        tree.pathfinder.destination = tree.target.position;

        if (tree.npcTransform.position.x - tree.pathfinder.destination.x > 0)
            tree.spriteRenderer.flipX = true;
        else
            tree.spriteRenderer.flipX = false;

        state = NodeState.RUNNING;
        return state;
    }
}
