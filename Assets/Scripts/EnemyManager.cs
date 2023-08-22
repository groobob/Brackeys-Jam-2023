using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Enemy Options")]
    [SerializeField] int maxEnemyCount;
    [SerializeField] float enemyOffset;

    [Header("Other Objects")]
    [SerializeField] Transform player;
    [SerializeField] GameObject enemy;

    public static EnemyManager instance;

    int enemyCount;

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        if(enemyCount < maxEnemyCount)
        {
            enemyCount++;
            Instantiate(enemy, new Vector3(Random.Range(-5, 5), player.position.y - (enemyOffset * enemyCount), 0), Quaternion.identity);
        }
    }

    public void SetMaxEnemyCount(int num)
    {
        maxEnemyCount = num;
    }

    public void SetEnemyOffset(float num)
    {
        enemyOffset = num;
    }

    public void DecreaseEnemyCount()
    {
        enemyCount--;
    }
}