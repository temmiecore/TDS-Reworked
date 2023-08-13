
using System.Collections.Generic;

public enum NodeState
{
    RUNNING,
    SUCCESS,
    FAILURE
}

public class Node 
{
    protected NodeState state;

    public Node parent;
    public BTreeController tree;
    protected List<Node> children = new List<Node>();

    private Dictionary<string, object> dataContext = new Dictionary<string, object>();

    public Node()
    {
        parent = null;
        tree = null;
    }

    public Node(BTreeController tree)
    {
        this.tree = tree;
    }

    public Node(List<Node> children)
    {
        foreach (Node child in children)
            Attach(child);
    }

    public void Attach(Node node)
    {
        node.parent = this;
        children.Add(node);
    }

    public virtual NodeState Execute() => NodeState.FAILURE;
}
