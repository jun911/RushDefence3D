using System;
using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private int cost = 25;
    [SerializeField] private float delayToSpawn = 0.5f;


    private void Start()
    {
        StartCoroutine(Build());
    }

    IEnumerator Build()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);

            foreach (Transform grandChild in child)
            {
                grandChild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);

            yield return new WaitForSeconds(delayToSpawn);

            foreach (Transform grandChild in child)
            {
                grandChild.gameObject.SetActive(true);
            }
        }

    }

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