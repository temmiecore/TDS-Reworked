using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttackRange : Node
{
    private string targetTag;
    private int layermask;

    public CheckAttackRange(BTreeController tree)
    {
        this.tree = tree;

        targetTag = "Player";

        layermask = LayerMask.GetMask("Player", "Enemy");
    }


    public override NodeState Execute()
    {
        object t = GetData("target");

        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(tree.transform.position, tree.attackRadius, layermask);

        foreach (Collider2D coll in colliders)
        {
            if (coll.tag == targetTag)
            {
                state = NodeState.SUCCESS;
                return state;
            }
        }

        state = NodeState.FAILURE;
        return state;
    }

    public void ChangeTargetToSeek(string targetTag)
    { this.targetTag = targetTag; }
}
