using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemyType : MonoBehaviour
{
    private EnemyContainerScript enemyType;
    private SpriteRenderer sprtR;
    private Rigidbody2D rb;

    private int fishSpeed = 0;

    private Transform playerLoc;
    private float changingForms = 1;
    private bool inChange = false;


    private int facing;
    // Start is called before the first frame update
    void Start()
    {
        playerLoc = this.transform.parent.gameObject.GetComponent<EnemyManager>().distanceFromPlayer().transform;
        sprtR = this.GetComponent<SpriteRenderer>();
        rb = this.GetComponent<Rigidbody2D>();

        int randomtype = Random.Range(0,100);
        if(randomtype >= 1 - (playerLoc.position.y/200) && randomtype < 34)
            randomtype = 1;

        else if(randomtype >= 33 && randomtype < 37 - (playerLoc.position.y/50))
            randomtype = 3;

        else if(randomtype >= 37 - (playerLoc.position.y/50) && randomtype < 99)
            randomtype = 0;

        else if(playerLoc.position.y < -70)
        {
            if(randomtype >= 98 && randomtype < 100)
                randomtype = 2;
            if(randomtype >= 0 && randomtype < 1 - (playerLoc.position.y/200))
                randomtype = 3;
        }    
        else if (randomtype >= 99 && randomtype < 100)
            randomtype = 0;
        else if(randomtype >= 0 && randomtype < 1 - (playerLoc.position.y/200))
            randomtype = 1;
        
        enemyType = this.transform.parent.gameObject.GetComponent<listAndAccessToEnemyTypes>().getEnemyType(randomtype);

        facing = Random.Range(-1, 1);

        if(enemyType.EnemyName == "MovingFish")
            sprtR.color = new Color(0.9402621f,0.9433962f,0.2981488f,1);
        if(enemyType.EnemyName == "FastMovingFish")
            sprtR.color = new Color(.99f,.99f,.99f,1);
        if(enemyType.EnemyName == "DeathFish")
        {
            sprtR.color = new Color(1f,0f,0f,1);
            this.gameObject.layer = 7;
        }

        if(enemyType.EnemyName == "AppearFish")
            sprtR.color = new Color(.7f,.32f,.5f,1);

        fishSpeed = enemyType.speed;

        if(facing == 0)
        {
            facing++;
        }

    }


    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(facing * fishSpeed, 0);
        if(this.transform.position.y - 40 > playerLoc.position.y)
            Destroy(this.gameObject);

        if(enemyType.hasSpikes)
        {
            if(changingForms < -.5f)
            {
                inChange = true;
            }
            else if(changingForms > 1f)
            {
                inChange = false;
            }
            if(inChange == false)
            {
                sprtR.color = new Color(.7f,.32f,.5f,changingForms);
                changingForms -= .01f;
            }
            if(inChange == true)
            {
                sprtR.color = new Color(.7f,.32f,.5f,changingForms);
                changingForms += .01f;
            }

            if(changingForms >= 0f)
            {
                this.gameObject.layer = 8;
            }
            else
            {
                this.gameObject.layer = 9;
            }
        }
    }

    void FixedUpdate()
    {
        this.transform.localScale = new Vector3(facing, 1, 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name != "Player")
        {
            facing = facing * -1;
        }

        if(collision.gameObject.name == "Player")
        {
            if(enemyType.deathTouch)
                Debug.Log("dead");
        }
    }
}
