using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ranking : MonoBehaviour
{
    private int[] bestScore = new int[5];
    private string[] bestName = new string[5];

    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponent<TMPro.TextMeshProUGUI>();
        ShowScore();
    }

    public void SetScore(int currentScore, string currentName)
    {
        Debug.Log("Set Start!");

        PlayerPrefs.SetString("CurrentPlayerName", currentName);
        PlayerPrefs.SetInt("CurrentPlayerScore", currentScore);

        int tempScore = 0;
        string tempName = "";

        for (int i = 0; i < 5; i++)
        {
            bestScore[i] = PlayerPrefs.GetInt(i + "BestScore");
            bestName[i] = PlayerPrefs.GetString(i + "BestName");

            while (bestScore[i] < currentScore)
            {
                tempScore = bestScore[i];
                tempName = bestName[i];
                bestScore[i] = currentScore;
                bestName[i] = currentName;

                PlayerPrefs.SetInt(i + "BestScore", currentScore);
                PlayerPrefs.SetString(i.ToString() + "BestName", currentName);

                currentScore = tempScore;
                currentName = tempName;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            Debug.Log(i + " Score : " + PlayerPrefs.GetInt(i + "BestScore"));
            Debug.Log(i + " Name : " + PlayerPrefs.GetString(i + "BestName"));
        }
    }

    public void ShowScore()
    {
        string tempText = "";

        for (int i = 0; i < 5; i++)
        {
            tempText += "Name : " + PlayerPrefs.GetString(i + "BestName") + "\n";
            tempText += "Score : " + PlayerPrefs.GetInt(i + "BestScore") + "\n\n";
        }

        scoreText.text = tempText;
    }
}
