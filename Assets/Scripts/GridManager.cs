using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Vector2Int gridSize;

    [Tooltip("World Grid Size - Should match UnityEditor snap settings.")]
    [SerializeField] private int unityGridSize = 10;

    public int UnityGridSize 
    { 
        get { return unityGridSize; } 
    }

    private Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid
    { 
        get { return grid; } 
    }

    private void Awake()
    {
        CreateGrid();
    }

    public void ResetNodes()
    {
        foreach(KeyValuePair<Vector2Int, Node> entry in grid)
        {
            entry.Value.connectedTo = null;
            entry.Value.isExplored = false;
            entry.Value.isPath = false;
        }
    }

    public Node GetNode(Vector2Int coordinate)
    {
        return grid.ContainsKey(coordinate) ? grid[coordinate] : null;
    }

    public void BlockNode(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable = false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(position.x / unityGridSize);
        coordinates.y = Mathf.RoundToInt(position.z / unityGridSize);

        return coordinates;
    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = Mathf.RoundToInt(coordinates.x * unityGridSize);
        position.z = Mathf.RoundToInt(coordinates.y * unityGridSize);
        position.y = Vector3.zero.y;

        return position;
    }

    private void CreateGrid()
    {
        Debug.Log("[1] create grid");

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coordinate = new Vector2Int(x, y);
                grid.Add(coordinate, new Node(coordinate, true));
            }
        }
    }
}