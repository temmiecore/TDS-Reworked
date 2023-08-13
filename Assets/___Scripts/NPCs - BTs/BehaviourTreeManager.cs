using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTreeManager : MonoBehaviour
{
    /// aka Big ass switch statement
    public Node SetupTree(BehaviourTreeType type, BTreeController tree)
    {
        switch (type)
        {
            case BehaviourTreeType.WanderingCircle:
                {
                    Node root = new Selector(new List<Node>
                    {
                        new Sequence(new List<Node>{
                                new CheckAttackRange(tree),
                                new TaskAttack(tree)
                        }),
                        new Sequence(new List<Node>{
                            new CheckAlertRange(tree),
                            new CheckIgnoreRange(tree),
                            new TaskApproachTarget(tree)
                        }),
                        new TaskWanderingCircle(tree)
                    });

                    return root;
                }

            case BehaviourTreeType.Wandering:
                {
                    Node root = new Selector(new List<Node>
                    {
                        new Sequence(new List<Node>{
                                new CheckAttackRange(tree),
                                new TaskAttack(tree)
                        }),
                        new Sequence(new List<Node>{
                            new CheckAlertRange(tree),
                            new CheckIgnoreRange(tree),
                            new TaskApproachTarget(tree)
                        }),
                        new TaskWandering(tree)
                    });

                    return root;
                }

            case BehaviourTreeType.Patrol:
                {

                    return null;
                }
        }

        return null;
    }
}
