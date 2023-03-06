using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] private Transform weapon;
    [SerializeField] private float range = 15f;
    [SerializeField] private float targetDistance;

    private Transform target;

    private void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    private void AimWeapon()
    {
        targetDistance = Vector3.Distance(transform.position, target.transform.position);
        weapon.LookAt(target);
        Attack(targetDistance < range);
    }

    private void Attack(bool isAttack)
    {
        if (transform.GetComponentInChildren<ParticleSystem>() != null)
        {
            var emission = transform.GetComponentInChildren<ParticleSystem>().emission;
            emission.enabled = isAttack;
        }
    }
}