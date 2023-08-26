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

    private int facing;
    // Start is called before the first frame update
    void Start()
    {
        sprtR = this.GetComponent<SpriteRenderer>();
        rb = this.GetComponent<Rigidbody2D>();

        int randomtype = Random.Range(0,100);

        if(randomtype >= 0 && randomtype < 34)
            randomtype = 1;

        if(randomtype >= 33 && randomtype < 95)
            randomtype = 0;

        if(randomtype >= 95 && randomtype < 100)
            randomtype = 2;    
        
        enemyType = this.transform.parent.gameObject.GetComponent<listAndAccessToEnemyTypes>().getEnemyType(randomtype);

        playerLoc = this.transform.parent.gameObject.GetComponent<EnemyManager>().distanceFromPlayer().transform;
        facing = Random.Range(-1, 1);

        if(enemyType.EnemyName == "MovingFish")
            sprtR.color = new Color(0.9402621f,0.9433962f,0.2981488f,1);
        if(enemyType.EnemyName == "FastMovingFish")
            sprtR.color = new Color(.99f,.99f,.99f,1);
        if(enemyType.EnemyName == "DeathFish")
            sprtR.color = new Color(1f,0f,0f,1);

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
