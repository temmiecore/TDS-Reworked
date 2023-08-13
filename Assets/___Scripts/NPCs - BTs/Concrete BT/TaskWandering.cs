using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TaskWandering : Node
{
    private float waitTime = 3f;
    private float waitCounter = 0f;
    private bool waiting = false;

    private bool isWalking = false;

    public TaskWandering(BTreeController tree)
    {
        this.tree = tree;
    }

    public override NodeState Execute()
    {
        if (waiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter > waitTime)
            {
                Debug.Log("Waiting end "+ tree.pathfinder.destination);
                waiting = false;
                isWalking = false;
                waitCounter = 0f;
            }
        }
        else
        {
            if (!isWalking)
            {
                tree.pathfinder.destination = PickRandomPoint();
                tree.pathfinder.SearchPath();
                isWalking = true;
            }
            else if (tree.pathfinder.reachedEndOfPath)
            {
                Debug.Log("Waiting " + tree.pathfinder.destination);
                waiting = true;
            }
        }


        state = NodeState.RUNNING;
        return state;
    }

    Vector3 PickRandomPoint()
    {
        var point = Random.insideUnitSphere * 0.32f;

        point.z = 0;
        point += tree.enemyTransform.position;
        return point;
    }

}
