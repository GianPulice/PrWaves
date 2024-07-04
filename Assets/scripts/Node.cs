using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Node 
{
    public Vector2Int Position { get; set; }
    public List<Node> Neighbors { get; set; }

    public Node(Vector2Int position)
    {
        Position = position;
        Neighbors = new List<Node>();
    }

    public void AddNeighbor(Node neighbor)
    {
        Neighbors.Add(neighbor);
    }
}