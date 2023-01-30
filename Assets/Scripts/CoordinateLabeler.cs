using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] private Color defaultcolor = Color.white;
    [SerializeField] private Color blockedColor = Color.gray;

    private Vector2Int coordinates = new Vector2Int();
    private TextMeshPro label;

    private Waypoint waypoint;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        DisplayCoordinates();
        waypoint = GetComponentInParent<Waypoint>();
    }

    private void Update()
    {
        //������忡���� ����
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        ColorCoordinates();
        ToggleLabels();
    }

    private void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    private void ColorCoordinates()
    {
        label.color = waypoint.IsPlaceable ? defaultcolor : blockedColor;
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