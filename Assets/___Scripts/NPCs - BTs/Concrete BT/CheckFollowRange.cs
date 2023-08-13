using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFollowRange : Node
{
    private Transform followTarget;

    public CheckFollowRange(BTreeController tree)
    {
        this.tree = tree;

        followTarget = tree.followTarget;
    }

    public override NodeState Execute()
    {
        if (followTarget == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        if (Vector2.Distance(tree.npcTransform.position, followTarget.position) > tree.followRadius)
        {
            tree.animator.SetBool("IsWalking", true);

            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
