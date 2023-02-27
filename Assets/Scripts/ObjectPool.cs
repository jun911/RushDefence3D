using System;
using System.Collections;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] [Range(0, 50)] private int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)] private float spawnTimer = 1f;
    [SerializeField] private GameObject enemyPrefab;

    private GameObject[] pools;

    private void Awake()
    {
        PopulatePool();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void PopulatePool()
    {
        pools = new GameObject[poolSize];

        Debug.Log($"pool size:{pools.Length}");

        for (int i = 0; i < pools.Length; i++)
        {
            Debug.Log("i:" + i);
            pools[i] = Instantiate(enemyPrefab, transform);
            pools[i].SetActive(false);
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();

            yield return new WaitForSeconds(spawnTimer);
        }
    }

    private void EnableObjectInPool()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            if(pools[i].activeInHierarchy == false)
            {
                pools[i].SetActive(true);
                break;
            }
        }
    }
}