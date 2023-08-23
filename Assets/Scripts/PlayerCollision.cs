using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
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
        playerMovementScript.rb.velocity = Vector2.zero;
        playerMovementScript.ApplyForce(new Vector2(0, boostForce * -1));
        Destroy(collision.gameObject);
        Debug.Log("trigger");
    }
}
