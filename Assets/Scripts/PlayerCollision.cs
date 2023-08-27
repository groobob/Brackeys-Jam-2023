using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] int boostForce;

    private Player playerMovementScript;

    private SpriteRenderer fadingIn;
    [SerializeField] private bool isDead = false;
    [SerializeField] private float x = 0;
    
    private void Awake()
    {
        playerMovementScript = this.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer);
        if(collision.gameObject.layer == 7) {
            Debug.Log(collision.gameObject.name);
            this.GetComponent<Player>().enabled = false;
            fadingIn = GameObject.Find("FadingOut").GetComponent<SpriteRenderer>();
            isDead = true;
        }
        else if(collision.gameObject.layer != 7)
        {
            playerMovementScript.canDash = true;
            playerMovementScript.rb.velocity = Vector2.zero;
            playerMovementScript.ApplyForce(new Vector2(0, boostForce * -1));
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        if(isDead == true)
        {
            fadingIn.color = new Color(0f,0f,0f,x);
            x = x +.001f;
        }
        if(x > .99f)
        {
            isDead = false;
            SceneManager.LoadScene("GameOver");
        }
    }
}
