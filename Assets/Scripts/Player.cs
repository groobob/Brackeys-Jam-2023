using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Reference variables
    [Header("Movement")]
    [SerializeField] float movementSpeed;

    [SerializeField] float aimedDashForce;

    [SerializeField] float sideDashForce;
    [SerializeField] float dashWindow;

    [SerializeField] float defaultGravity;
    [SerializeField] float floatationGravity;

    private PlayerAudio getClips;

    private List<AudioClip> playerClipsList;

    private AudioSource audioData;
    private AudioClip audioClip;

    [SerializeField] private SpriteRenderer sprtR;
    private float dashEffect = 0;

    float dashTimerA;
    float dashTimerD;
    bool awaitingSecondInputA = false;
    bool awaitingSecondInputD = false;

    public bool canDash = true;

    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioData = GetComponent<AudioSource>();

        getClips = GetComponent<PlayerAudio>();

        playerClipsList = getClips.clips;


    }
    void Update()
    {
        if(dashEffect < 1f)
        {
            sprtR.color = new Color(dashEffect, dashEffect, dashEffect, 1);
            dashEffect += .1f;
        }
        // Movement
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed * 1000, 0), ForceMode2D.Force);

        //Double tap dash
        if(awaitingSecondInputA) dashTimerA += Time.deltaTime;
        if(awaitingSecondInputD) dashTimerD += Time.deltaTime;

        if(dashTimerA > dashWindow)
        {
            awaitingSecondInputA = false;
            dashTimerA = 0;
        }
        if(dashTimerD > dashWindow)
        {
            awaitingSecondInputD = false;
            dashTimerD = 0;
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            if(awaitingSecondInputA)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                rb.AddForce(new Vector2(sideDashForce * -1 * 10, 0), ForceMode2D.Impulse);
                awaitingSecondInputA = false;
                dashTimerA = 0;
                audioClip = playerClipsList[0];
                audioData.PlayOneShot(audioClip);
                dashEffect = .3f;
                sprtR.color = new Color(dashEffect, dashEffect + .1f, dashEffect + .2f, 1);
            }
            else awaitingSecondInputA = true;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            if(awaitingSecondInputD)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                rb.AddForce(new Vector2(sideDashForce * 10, 0), ForceMode2D.Impulse);
                awaitingSecondInputD = false;
                dashTimerD = 0;
                audioClip = playerClipsList[0];
                audioData.PlayOneShot(audioClip);
                dashEffect = .5f;
                sprtR.color = new Color(dashEffect + .3f, dashEffect + .2f, dashEffect, 1);
            }
            awaitingSecondInputD = true;
        }

        // Aimed Dash
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetKeyDown(KeyCode.Mouse0) && canDash)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized * aimedDashForce * 10, ForceMode2D.Impulse);
            canDash = false;
        }

        // Slowed floating
        if(Input.GetKey(KeyCode.S))
        {
            rb.gravityScale = floatationGravity;
        }
        else
        {
            rb.gravityScale = defaultGravity;
        }
    }

    public void ApplyForce(Vector2 input)
    {
        rb.AddForce(input, ForceMode2D.Impulse);
    }
}
