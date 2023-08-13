using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAlertRange : Node 
{
    private string targetTag;
    private int layermask;

    public CheckAlertRange(BTreeController tree)
    {
        this.tree = tree;

        targetTag = "Player"; /// By default

        layermask = LayerMask.GetMask("Player", "Enemy");
    }

    public override NodeState Execute()
    {
        object t = GetData("target");

        if (t == null)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(tree.enemyTransform.position, tree.alertRadius, layermask);

            foreach (Collider2D coll in colliders)
            {
                if (coll.tag == targetTag)
                {
                    parent.parent.SetData("target", coll.transform);
                    tree.animator.SetBool("IsWalking", true);

                    tree.target = coll.transform;
                    tree.isAlerted = true;

                    state = NodeState.SUCCESS;
                    return state;
                }
            }

            state = NodeState.FAILURE;
            return state;
        }

        tree.animator.SetBool("IsWalking", true);
        state = NodeState.SUCCESS;
        return state;
    }

    public void ChangeTargetToSeek(string targetTag)
    { this.targetTag = targetTag; }

}
