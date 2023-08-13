using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAlertRange : Node
{
    private int layermask;

    public CheckAlertRange(BTreeController tree)
    {
        this.tree = tree;

        layermask = LayerMask.GetMask("Player", "Enemies", "NPC");
    }

    public override NodeState Execute()
    {
        if (tree.target == null || tree.target.Equals(null))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(tree.npcTransform.position, tree.alertRadius, layermask);

            foreach (Collider2D coll in colliders)
            {
                if (coll.GetComponent<BTreeController>()?.isFriendly == !tree.isFriendly || (!tree.isFriendly && coll.tag == "Player"))
                {
                    tree.target = coll.transform;
                    tree.animator.SetBool("IsWalking", true);
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
}
