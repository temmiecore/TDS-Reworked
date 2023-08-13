using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TaskWanderingCircle : Node
{
    private float waitTime = 3f;
    private float waitCounter = 0f;
    private bool waiting = false;

    private bool isWalking = false;
    private Vector3 originalPoint;

    public TaskWanderingCircle(BTreeController tree)
    {
        this.tree = tree;
        originalPoint = tree.enemyTransform.position;
    }

    public override NodeState Execute()
    {
        if (waiting)
        {
            tree.animator.SetBool("IsWalking", false);
            waitCounter += Time.deltaTime;
            if (waitCounter > waitTime)
            {
                waiting = false;
                isWalking = false;
                waitCounter = 0f;
            }
        }
        else
        {
            tree.animator.SetBool("IsWalking", true);
            if (!isWalking)
            {
                tree.pathfinder.destination = PickRandomPoint();
                tree.pathfinder.SearchPath();
                isWalking = true;
            }
            else if (tree.pathfinder.reachedEndOfPath)
            {
                waiting = true;
            }
        }

        if (tree.enemyTransform.position.x - tree.pathfinder.destination.x > 0)
            tree.spriteRenderer.flipX = true;
        else
            tree.spriteRenderer.flipX = false;

        state = NodeState.RUNNING;
        return state;
    }

    Vector3 PickRandomPoint()
    {
        var point = Random.insideUnitSphere * 0.32f;

        point.z = 0;
        point += originalPoint;
        return point;
    }

}
