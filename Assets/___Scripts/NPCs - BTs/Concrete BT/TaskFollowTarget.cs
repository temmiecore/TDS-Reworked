using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskFollowTarget : Node
{
    public TaskFollowTarget(BTreeController tree)
    {
        this.tree = tree;
    }

    public override NodeState Execute()
    {
        tree.pathfinder.destination = tree.followTarget.position + (tree.npcTransform.position - tree.followTarget.position).normalized * 0.24f;

        if (tree.npcTransform.position.x - tree.pathfinder.destination.x > 0)
            tree.spriteRenderer.flipX = true;
        else
            tree.spriteRenderer.flipX = false;

        state = NodeState.SUCCESS;
        return state;
    }
}
