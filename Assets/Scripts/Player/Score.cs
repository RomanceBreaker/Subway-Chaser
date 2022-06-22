using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponent<TMPro.TextMeshProUGUI>();
        scoreText.text = "0";
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
