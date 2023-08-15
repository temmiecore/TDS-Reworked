using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TaskCalculateThreat : Node
{
    public TaskCalculateThreat(BTreeController tree)
    {
        this.tree = tree;
    }

    public override NodeState Execute()
    {
        if (tree.threatList.Count == 0)
        {
            state = NodeState.FAILURE;
            return state;
        }

        KeyValuePair<Transform, float> highestThreat = tree.threatList.OrderBy(pair => pair.Value).Last();
        float currentThreat = tree.threatList[tree.target];

        if (highestThreat.Value - currentThreat > 3)
            tree.target = highestThreat.Key;

        state = NodeState.FAILURE;
        return state;
    }
}
