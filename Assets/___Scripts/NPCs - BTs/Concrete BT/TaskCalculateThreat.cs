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

        if (highestThreat.Value - currentThreat > 5)
            tree.target = highestThreat.Key;

        if (tree.name == "Orc Grunt (95)")
        {
            Debug.Log("----------------------------------------");
            Debug.Log("Highest threat = " + highestThreat.Key.name);
            foreach (KeyValuePair<Transform, float> pair in tree.threatList)
                Debug.Log(pair.Key.name + " " + pair.Value);
        }

        state = NodeState.FAILURE;
        return state;
    }
}
