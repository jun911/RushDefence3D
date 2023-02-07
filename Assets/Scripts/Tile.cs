using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Tower towerPrefab;

    [Tooltip("구조물 설치 가능 여부")]
    [SerializeField] private bool isPlaceable;

    public bool IsPlaceable
    { get { return isPlaceable; } }

    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }

    private void Start()
    {
        SetGridWalkable();
    }

    void SetGridWalkable()
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if(isPlaceable == false)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BuildTower();
        }
    }

    private void BuildTower()
    {
        if (isPlaceable)
        {
            isPlaceable = !towerPrefab.CreateTower(towerPrefab, transform.position);
        }
    }
}