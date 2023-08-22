using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] int boostForce;

    private Player playerMovementScript;
    
    private void Awake()
    {
        playerMovementScript = this.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMovementScript.canDash = true;
        playerMovementScript.ApplyForce(new Vector2(0, boostForce * -1));
        EnemyManager.instance.DecreaseEnemyCount();
        EnemyManager.instance.SpawnEnemy();
        Destroy(collision.gameObject);
    }
}
