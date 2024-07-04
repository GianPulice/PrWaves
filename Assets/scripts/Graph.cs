using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Graph
{
    public Dictionary<Vector2Int, Node> Nodes { get; set; }

    public Graph()
    {
        Nodes = new Dictionary<Vector2Int, Node>();
    }

    public void AddNode(Vector2Int position)
    {
        if (!Nodes.ContainsKey(position))
        {
            Nodes[position] = new Node(position);
        }
    }

    public void AddEdge(Vector2Int from, Vector2Int to)
    {
        if (Nodes.ContainsKey(from) && Nodes.ContainsKey(to))
        {
            Nodes[from].AddNeighbor(Nodes[to]);
            Nodes[to].AddNeighbor(Nodes[from]);
        }
    }

    public Node GetNode(Vector2Int position)
    {
        Nodes.TryGetValue(position, out Node node);
        return node;
    }
}


