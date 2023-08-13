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
        object t = GetData("target");

        if (t == null)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(tree.npcTransform.position, tree.alertRadius, layermask);

            foreach (Collider2D coll in colliders)
            {
                if (!tree.isFriendly)
                {
                    if (coll.tag == "Player" || coll.tag == "NPC")
                    {
                        parent.parent.SetData("target", coll.transform);
                        tree.animator.SetBool("IsWalking", true);

                        tree.target = coll.transform;
                        tree.isAlerted = true;

                        state = NodeState.SUCCESS;
                        return state;
                    }
                }
                else
                {
                    if (coll.tag == "Enemy")
                    {
                        parent.parent.SetData("target", coll.transform);
                        tree.animator.SetBool("IsWalking", true);

                        tree.target = coll.transform;
                        tree.isAlerted = true;

                        Debug.Log("found target " + coll.tag);

                        state = NodeState.SUCCESS;
                        return state;
                    }
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
