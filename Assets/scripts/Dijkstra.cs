using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Dijkstra
{
    public static List<Vector2Int> FindPath(Graph graph, Vector2Int start, Vector2Int target, List<Vector2Int> enemyPositions)
    {
        var unvisited = new List<Node>(graph.Nodes.Values);
        var distances = new Dictionary<Node, float>();
        var previous = new Dictionary<Node, Node>();

        foreach (var node in unvisited)
        {
            distances[node] = float.MaxValue;
        }

        distances[graph.GetNode(start)] = 0;

        while (unvisited.Count > 0)
        {
            unvisited.Sort((a, b) => distances[a].CompareTo(distances[b]));
            var current = unvisited[0];
            unvisited.Remove(current);

            if (current.Position == target)
            {
                var path = new List<Vector2Int>();
                while (previous.ContainsKey(current))
                {
                    path.Add(current.Position);
                    current = previous[current];
                }
                path.Reverse();
                return path;
            }

            foreach (var neighbor in current.Neighbors)
            {
                if (unvisited.Contains(neighbor) && !enemyPositions.Contains(neighbor.Position))
                {
                    float newDist = distances[current] + Vector2Int.Distance(current.Position, neighbor.Position);
                    if (newDist < distances[neighbor])
                    {
                        distances[neighbor] = newDist;
                        previous[neighbor] = current;
                    }
                }
            }
        }

        return new List<Vector2Int>();
    }
}
