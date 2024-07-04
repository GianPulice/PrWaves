using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    public Vector2Int gridPosition;

    private void OnMouseDown()
    {
     
        GameManager.Instance.MovePlayerTo(gridPosition);
    }
}
