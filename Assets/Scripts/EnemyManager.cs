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
    
    private GameObject tempEnemy;

    private GameObject playerConnection;

    int enemyCount;

    private void Awake()
    {
        enemyCount++;
        tempEnemy = Instantiate(enemy, new Vector3(Random.Range(-3, 3), player.position.y - 5, 0), Quaternion.identity);
        tempEnemy.transform.parent = gameObject.transform;
        instance = this;
        for(int i = 0; i < 3; i++)
        {
            enemyCount++;
            tempEnemy = Instantiate(enemy, new Vector3(Random.Range(-3, 3), player.position.y - (5 * i) - 10, 0), Quaternion.identity);            
            tempEnemy.transform.parent = gameObject.transform;
        }
    }

    private void Start()
    {
        playerConnection = GameObject.Find("Camera Confiner");
    }

    public void SpawnEnemy()
    {

        tempEnemy = Instantiate(enemy, new Vector3(Random.Range(-3, 3), player.position.y - 18 - Random.Range(-3, 0), 0), Quaternion.identity);
        tempEnemy.transform.parent = gameObject.transform;
        tempEnemy = Instantiate(enemy, new Vector3(Random.Range(-3, 3), player.position.y - 18 - Random.Range(0, 5), 0), Quaternion.identity);
        tempEnemy.transform.parent = gameObject.transform;
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

    public GameObject distanceFromPlayer()
    {
        return playerConnection;
    }


}
