using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameStartingAnim : MonoBehaviour
{
    private Rigidbody2D rb;
    private Player playerscript;
    void Awake()
    {
        playerscript = GetComponent<Player>();
        rb = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(this.transform.position.y > -2)
        {
            rb.AddForce(Vector2.down * 1, ForceMode2D.Impulse);
        }
        else
        {
            playerscript.enabled = true;
        }
    }
}
