using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tree : MonoBehaviour
{
    private Node root = null;

    protected virtual void Start()
    {
        root = SetupTree();
    }

    void Update()
    {
        if (root != null)
            root.Execute();
    }

    protected abstract Node SetupTree();
}
