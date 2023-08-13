using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFollowRange : Node
{
    public CheckFollowRange(BTreeController tree)
    {
        this.tree = tree;
    }

    public override NodeState Execute()
    {
        if (tree.followTarget == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        if (Vector2.Distance(tree.npcTransform.position, tree.followTarget.position) > tree.followRadius)
        {
            tree.animator.SetBool("IsWalking", true);

            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
