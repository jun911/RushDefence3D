using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField][Range(0f, 5f)] private float speed = 1f;
    private List<Tile> path = new List<Tile>();

    private Enemy enemy;

    private void Awake()
    {
        enemy = transform.GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    private void FindPath()
    {
        path.Clear();

        GameObject waypoints = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in waypoints.transform)
        {
            Tile waypoint = child.GetComponent<Tile>();
            if (waypoint != null)
            {
                path.Add(waypoint);
            }
        }
    }

    private void ReturnToStart()
    {
        if (path[0] != null)
        {
            transform.position = path[0].transform.position;
        }
    }

    private IEnumerator FollowPath()
    {
        foreach (var waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);

                yield return new WaitForEndOfFrame();
            }
        }

        FinishPath();
    }

    private void FinishPath()
    {
        gameObject.SetActive(false);
        enemy.StealGold();
    }
}