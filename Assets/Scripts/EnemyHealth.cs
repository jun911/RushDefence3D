using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;

    [Tooltip("리로드시 증가되는 체력")]
    [SerializeField] private int difficultyRamp = 1;

    private int currentHealth = 0;

    public int CurrentHealth { get { return currentHealth; } }
    private Enemy enemy;

    private void Awake()
    {
        enemy = transform.GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            maxHealth += difficultyRamp;
            enemy.RewardGold();
        }
    }
}