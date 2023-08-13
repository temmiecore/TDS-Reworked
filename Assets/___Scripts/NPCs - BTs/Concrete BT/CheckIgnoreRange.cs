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
        object t = GetData("target");

        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        Transform targetPosition = (Transform)t;
        
        if (Vector2.Distance(tree.enemyTransform.position, targetPosition.position) > tree.ignoreRadius)
        {
            tree.isAlerted = false;

            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
    }
}
