using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyManager.instance.DecreaseEnemyCount();
        EnemyManager.instance.SpawnEnemy();
        Destroy(gameObject);
    }
}
