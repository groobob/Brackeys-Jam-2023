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
    int bonusScore = 0;

    void Update()
    {
        if (lowestDepth > player.transform.position.y)
        {
            depthText.text = "Depth: " + (int) player.transform.position.y * -1 + "m";
            lowestDepth = (int) player.transform.position.y;
        }
        scoreText.text = "Score: " + (-1 * lowestDepth * 10 + bonusScore);
    }

    public void AddScore(int score)
    {
        bonusScore += score;
    }
}
