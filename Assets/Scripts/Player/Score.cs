using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        Debug.Log(score);

        scoreText.text = score.ToString();
    }
}
