using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_S : MonoBehaviour
{
    bool pause;

    void Start()
    {
        pause = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pause == false) //퍼즈를 걸겠다
            {
                Time.timeScale = 0f;
                pause = true;
                this.transform.GetChild(0).gameObject.SetActive(true);
                Debug.Log("퍼즈 on");
            }
           
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Time.timeScale = 0f;
            this.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    //Pause_UI
    public void Game_Pause()
    {
        
    }
    
    public void Game_Main()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void Game_Resume()
    {
        Time.timeScale = 1f;
        pause = false;
        this.transform.GetChild(0).gameObject.SetActive(false);
        Debug.Log("퍼즈 off");
    }

    public void Gmae_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //End_UI
    public void Game_End()
    {

    }

    public void Game_Score()
    {
        this.transform.GetChild(1).gameObject.transform.GetChild(2).transform.GetChild(1).gameObject.SetActive(true);
    }


}
