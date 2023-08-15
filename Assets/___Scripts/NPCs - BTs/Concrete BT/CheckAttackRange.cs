using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttackRange : Node
{
    public CheckAttackRange(BTreeController tree)
    {
        this.tree = tree;
    }

    public override NodeState Execute()
    {
        try
        {
            if (Vector2.Distance(tree.npcTransform.position, tree.target.position) < tree.attackRadius)
            {
                tree.pathfinder.destination = tree.target.position;
                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FAILURE;
            return state;
        }
        catch
        {
            state = NodeState.FAILURE;
            return state;
        }
    }
}
