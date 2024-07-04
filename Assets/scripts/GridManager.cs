using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GridManager : MonoBehaviour
{
    public GameObject cellPrefab;
    public GameObject enemyPrefab;
    public GameObject itemPrefab;
    public C_Movement playerController;
    public int gridWidth = 10;
    public int gridHeight = 10;
    public float cellSize = 1.0f;
    public float enemyZOffset = 10f;
    public float itemZOffset = 10f;
    public int enemys;
    public int items;
    public List<Vector2Int> itemPositions;
    public List<Vector2Int> enemyPositions;
    public List<int> itemIds;

    public Graph graph;
    public BinarySearchTree<ComparableVector2Int> enemyPositionTree;

    void Start()
    {
        graph = new Graph();
        enemyPositionTree = new BinarySearchTree<ComparableVector2Int>();
        enemyPositions = new List<Vector2Int>();
        itemPositions = new List<Vector2Int>();
        GenerateGrid();
        GenerateEnemies(enemys);
        GenerateItems(items);
    }

    void GenerateGrid()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector2 position = new Vector2(x * cellSize, y * cellSize);
                GameObject newCell = Instantiate(cellPrefab, position, Quaternion.identity);
                newCell.transform.SetParent(transform);
                GridCell cell = newCell.GetComponent<GridCell>();
                cell.gridPosition = new Vector2Int(x, y);

                graph.AddNode(cell.gridPosition);

                Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
                foreach (var dir in directions)
                {
                    Vector2Int neighborPos = cell.gridPosition + dir;
                    if (neighborPos.x >= 0 && neighborPos.x < gridWidth && neighborPos.y >= 0 && neighborPos.y < gridHeight)
                    {
                        graph.AddEdge(cell.gridPosition, neighborPos);
                    }
                }
            }
        }
    }

    public Node GetNode(Vector2Int position)
    {
        return graph.GetNode(position);
    }

    void GenerateEnemies(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            int randomX = Random.Range(0, gridWidth);
            int randomY = Random.Range(0, gridHeight);
            Vector2Int randomPosition = new Vector2Int(randomX, randomY);

            ComparableVector2Int newNode = new ComparableVector2Int(randomPosition);
            if (randomPosition != playerController.currentGridPosition && !enemyPositionTree.Search(newNode))
            {
                Vector3 enemyPosition = new Vector3(randomX * cellSize, randomY * cellSize, -enemyZOffset);
                GameObject enemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
                enemyPositionTree.Insert(newNode);
                enemyPositions.Add(randomPosition);
            }
            else
            {
                i--;
            }
        }
    }

    void GenerateItems(int numberOfItems)
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            int randomX = Random.Range(0, gridWidth);
            int randomY = Random.Range(0, gridHeight);
            Vector2Int randomPosition = new Vector2Int(randomX, randomY);

            if (!enemyPositions.Contains(randomPosition) && !ItemPositionOccupied(randomPosition))
            {
                Vector3 itemPosition = new Vector3(randomX * cellSize, randomY * cellSize, -itemZOffset);
                GameObject item = Instantiate(itemPrefab, itemPosition, Quaternion.identity);
                int itemId = GenerateItemId();
                item.GetComponent<Item>().itemId = itemId;
                itemPositions.Add(randomPosition);
            }
            else
            {
                i--;
            }
        }
    }

    bool ItemPositionOccupied(Vector2Int position)
    {
        foreach (Vector2Int itemPosition in itemPositions)
        {
            if (itemPosition == position)
            {
                return true;
            }
        }
        return false;
    }

    int GenerateItemId()
    {
        return Random.Range(0, 7); 
    }

    public GameObject GetItemGameObjectAtPosition(Vector2Int position)
    {
        foreach (Transform child in transform)
        {
            Item item = child.GetComponent<Item>();
            if (item != null && item.transform.position == new Vector3(position.x * cellSize, position.y * cellSize, -itemZOffset))
            {
                return item.gameObject;
            }
        }
        return null;
    }
}


