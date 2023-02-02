using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Vector2Int gridSize;
    private Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    private void Awake()
    {
        CreateGrid();
    }

    public Node GetNode(Vector2Int coordinate)
    {
        return grid.ContainsKey(coordinate) ? grid[coordinate] : null;
    }

    private void CreateGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coordinate = new Vector2Int(x, y);
                grid.Add(coordinate, new Node(coordinate, true));
                //Debug.Log(grid[coordinate].coordinates + "=" + grid[coordinate].isWalkable);
            }
        }
    }
}