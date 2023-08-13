using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIgnoreRange : Node
{
    public CheckIgnoreRange(BTreeController tree)
    {
        this.tree = tree;
    }

    public override NodeState Execute()
    {
        try
        {
            if (Vector2.Distance(tree.npcTransform.position, tree.target.position) > tree.ignoreRadius)
            {
                tree.isAlerted = false;

                state = NodeState.FAILURE;
                return state;
            }

            state = NodeState.SUCCESS;
            return state;
        }
        catch
        {
            state = NodeState.SUCCESS;
            return state;
        }
    }
}
