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

    [SerializeField] float defaultFloatationDrag;
    [SerializeField] float floatationDrag;

    float dashTimerA;
    float dashTimerD;
    bool awaitingSecondInputA = false;
    bool awaitingSecondInputD = false;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
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
                rb.AddForce(new Vector2(sideDashForce * -1 * 10, 0), ForceMode2D.Impulse);
                awaitingSecondInputA = false;
                dashTimerA = 0;
            }
            else awaitingSecondInputA = true;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            if(awaitingSecondInputD)
            {
                rb.AddForce(new Vector2(sideDashForce * 10, 0), ForceMode2D.Impulse);
                awaitingSecondInputD = false;
                dashTimerD = 0;
            }
            awaitingSecondInputD = true;
        }

        // Aimed Dash
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.AddForce(new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized * aimedDashForce * 10, ForceMode2D.Impulse);
        }

        // Slowed floating
        if(Input.GetKey(KeyCode.S))
        {
            rb.drag = floatationDrag;
        }
        else
        {
            rb.drag = defaultFloatationDrag;
        }
    }
}
