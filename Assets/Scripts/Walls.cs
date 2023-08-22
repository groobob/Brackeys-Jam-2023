using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    [SerializeField] Transform player;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
    }
}
