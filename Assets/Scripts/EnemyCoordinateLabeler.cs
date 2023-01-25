using TMPro;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class EnemyCoordinateLabeler : MonoBehaviour
{
    private TextMeshPro label;
    private Vector2Int coordinates;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
        }
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / EditorSnapSettings.move.z);

        label.text = $"[{coordinates.x.ToString()}, {coordinates.y.ToString()}]";
    }
}