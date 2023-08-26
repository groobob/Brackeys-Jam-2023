using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFloat : MonoBehaviour
{
    [SerializeField] float floatationStrength;
    [SerializeField] float floatationSpeed;

    float timeElapsed;
    float originalYPosition;

    void Awake()
    {
        originalYPosition = transform.position.y;
    }
    void Update()
    {
        timeElapsed += Time.deltaTime * floatationSpeed;
        transform.position = new Vector3(transform.position.x, originalYPosition + (Mathf.Sin(timeElapsed) * floatationStrength), transform.position.z);
    }
}
