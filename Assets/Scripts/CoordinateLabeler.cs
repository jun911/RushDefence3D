using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    private Vector2Int coordinates = new Vector2Int();
    private TextMeshPro label;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }

    private void Update()
    {
        // 편집모드에서만 동작
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = $"{coordinates.x.ToString()},{coordinates.y.ToString()}";
    }

    private void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}