using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    [SerializeField] Transform camerapos;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, camerapos.position.y+2, transform.position.z);
    }
}
