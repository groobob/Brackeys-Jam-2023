using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            SceneManager.LoadScene("Menu");
    }

}
