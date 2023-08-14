using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                if (tree.threatList.Count != 0)
                {
                    tree.target = tree.threatList.Keys.First();
                    state = NodeState.SUCCESS;
                    return state;
                }

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
