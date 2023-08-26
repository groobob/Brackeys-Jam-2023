using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform playerPosition;
    private GameObject enemyManager;
    EnemyManager em;
    void Start()
    {
        playerPosition = GameObject.Find("Player").GetComponent<Transform>();
        enemyManager = GameObject.Find("Enemy Manager");
        em = enemyManager.GetComponent<EnemyManager>();
    }

    void Update()
    {
        if(playerPosition.position.y < this.transform.position.y - 5)
        {
            this.transform.position = playerPosition.position;

            em.SpawnEnemy();
        }
    }
}
