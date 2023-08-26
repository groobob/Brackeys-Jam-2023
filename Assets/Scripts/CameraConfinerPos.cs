using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConfinerPos : MonoBehaviour
{
    [SerializeField] Transform playerspt;

    void Update()
    {
        if(playerspt.position.y < this.transform.position.y) transform.position = new Vector3(transform.position.x, playerspt.position.y, transform.position.z);
    }
}
