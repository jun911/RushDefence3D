using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private int cost = 25;

    public bool CreateTower(Tower towerPrefab, Vector3 wayPosition)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null) { return false; }
        if (bank.CurrentBalance < cost) { return false; }

        bank.Withdrawal(cost);
        Instantiate(towerPrefab.gameObject, wayPosition, Quaternion.identity);

        return true;
    }
}