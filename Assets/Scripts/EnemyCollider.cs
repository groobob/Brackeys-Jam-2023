using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] int boostForce;

    [Header("Other Objects")]
    [SerializeField] Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.canDash = true;
        player.ApplyForce(new Vector2(boostForce * -1, 0));
        EnemyManager.instance.DecreaseEnemyCount();
        Destroy(gameObject);
    }
}
