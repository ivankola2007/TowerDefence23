using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Vector3 finishPoint;
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private EnemyData enemyData;
    [SerializeField]
    private GameObject boomFxPrefab;

    private uint health;

    private void Awake()
    {
        finishPoint = GameObject.FindGameObjectWithTag("Finish").transform.position;
    }

    private void Start()
    {
        agent.destination = finishPoint;
        agent.speed = enemyData.speed;
        health = enemyData.maxHealth;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }

    public void GetDamage()
    {
        Instantiate(boomFxPrefab, transform.position, Quaternion.Euler(-90f, 0f, 0f));
        Destroy(gameObject);
    }
}
