using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector: Node
{
    public Selector() : base() { }
    public Selector(List<Node> children) : base(children) { }


    public override NodeState Execute()
    {
        foreach (Node child in children)
        {
            switch (child.Execute())
            {
                case NodeState.FAILURE:
                    continue;
                case NodeState.SUCCESS:
                    state = NodeState.SUCCESS; return state;
                case NodeState.RUNNING:
                    state = NodeState.RUNNING; return state;
                default:
                    continue;
            }
        }

        state = NodeState.FAILURE;
        return state;
    }
}
