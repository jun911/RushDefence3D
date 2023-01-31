using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Tower towerPrefab;

    [Tooltip("������ ��ġ ���� ����")]
    [SerializeField] private bool isPlaceable;

    public bool IsPlaceable
    { get { return isPlaceable; } }

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