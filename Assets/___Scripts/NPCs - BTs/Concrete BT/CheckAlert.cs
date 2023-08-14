using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckAlert : Node
{
    private int layermask;

    public CheckAlert(BTreeController tree)
    {
        this.tree = tree;

        layermask = LayerMask.GetMask("Player", "Enemies", "NPC");
    }

    public override NodeState Execute()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(tree.npcTransform.position, tree.alertRadius, layermask);

        foreach (Collider2D coll in colliders)
        {
            if (coll.GetComponent<BTreeController>()?.isFriendly == !tree.isFriendly || (!tree.isFriendly && coll.tag == "Player"))
            {
                if (!tree.threatList.ContainsKey(coll.transform))
                {
                    tree.threatList.Add(coll.transform, 1);
                    coll.GetComponent<BTreeController>()?.attackersList.Add(tree);
                }
            }
        }

        if (tree.target == null && tree.threatList.Count != 0)
        {
            tree.target = tree.threatList.Keys.First();
            tree.animator.SetBool("IsWalking", true);
        }

        state = NodeState.SUCCESS;
        return state;
    }
}
