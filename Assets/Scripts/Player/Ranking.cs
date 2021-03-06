using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ranking : MonoBehaviour
{
    private int[] bestScore = new int[5];
    private string[] bestName = new string[5];
    private string currName;
    private int currScore;

    public TextMeshProUGUI scoreText;

    void Start()
    {
        currName = IDmanager.ID;
        currScore = IDmanager.score;

        SetScore();
    }

    public void SetScore()
    {
        Debug.Log("Set Start!");

        PlayerPrefs.SetString("CurrentPlayerName", currName);
        PlayerPrefs.SetInt("CurrentPlayerScore", currScore);

        int tempScore = 0;
        string tempName = "";

        for (int i = 0; i < 5; i++)
        {
            bestScore[i] = PlayerPrefs.GetInt(i + "BestScore");
            bestName[i] = PlayerPrefs.GetString(i + "BestName");

            while (bestScore[i] < currScore)
            {
                tempScore = bestScore[i];
                tempName = bestName[i];
                bestScore[i] = currScore;
                bestName[i] = currName;

                PlayerPrefs.SetInt(i + "BestScore", currScore);
                PlayerPrefs.SetString(i.ToString() + "BestName", currName);

                currScore = tempScore;
                currName = tempName;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            Debug.Log(i + " Score : " + PlayerPrefs.GetInt(i + "BestScore"));
            Debug.Log(i + " Name : " + PlayerPrefs.GetString(i + "BestName"));
        }

        ShowScore();
    }

    public void ShowScore()
    {
        string tempText = "";

        tempText += "Current Name : " + currName + "\n";
        tempText += "Current Score : " + currScore + "\n";
        tempText += "-----\n\n";

        for (int i = 0; i < 5; i++)
        {
            tempText += (i + 1).ToString() + ". Name : " + PlayerPrefs.GetString(i + "BestName") + "\n";
            tempText += "Score : " + PlayerPrefs.GetInt(i + "BestScore") + "\n\n";
        }

        scoreText.text = tempText;
    }
}
