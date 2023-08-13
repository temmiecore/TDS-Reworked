using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttackRange : Node
{
    private int layermask;

    public CheckAttackRange(BTreeController tree)
    {
        this.tree = tree;

        layermask = LayerMask.GetMask("Player", "Enemies", "NPC");
    }

    public override NodeState Execute()
    {
        object t = GetData("target");

        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        Transform target = (Transform)t;

        if (Vector2.Distance(tree.npcTransform.position, target.position) < tree.attackRadius)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
