using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIElements : MonoBehaviour
{
    // Reference Variables
    [Header("Text")]
    [SerializeField] TextMeshProUGUI depthText;
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("Other Objects")]
    [SerializeField] GameObject player;

    int lowestDepth = 0;
    void Update()
    {
        if (lowestDepth < player.transform.position.y)
        {
            depthText.text = "Depth: " + (int) player.transform.position.y + "m";
            lowestDepth = (int) player.transform.position.y;
        }
    }
}
