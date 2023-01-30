using TMPro;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class EnemyCoordinateLabeler : MonoBehaviour
{
    private TextMeshPro label;
    private EnemyHealth enemyHealth;

    private void Start()
    {
        label = GetComponent<TextMeshPro>();
        enemyHealth = FindObjectOfType<EnemyHealth>();
    }

    private void Update()
    {
        DisplayHealth();
    }

    private void DisplayHealth()
    {
        label.text = $"{enemyHealth.CurrentHealth}";
    }
}