using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_S : MonoBehaviour
{
    bool pause;
    public AudioSource audio_s;
    public AudioSource bgm_s;

    void Start()
    {
        pause = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audio_s.Play();
            if (pause == false) //퍼즈를 걸겠다
            {
                bgm_s.Pause();
                Time.timeScale = 0f;
                pause = true;
                this.transform.GetChild(0).gameObject.SetActive(true);
                Debug.Log("퍼즈 on");
            }
           
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            bgm_s.UnPause();
            audio_s.UnPause();
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
        Time.timeScale = 1f;
        audio_s.Play();
        SceneManager.LoadScene("Lobby");
    }

    public void Game_Resume()
    {
        audio_s.Play();
        bgm_s.UnPause();
        Time.timeScale = 1f;
        pause = false;
        this.transform.GetChild(0).gameObject.SetActive(false);
        Debug.Log("퍼즈 off");
    }

    public void Gmae_Restart()
    {
        Time.timeScale = 1f;
        audio_s.Play();
        SceneManager.LoadScene("Game_Start");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //End_UI
    public void Game_End()
    {

    }

    public void Game_Score()
    {
        audio_s.Play();
        this.transform.GetChild(1).gameObject.transform.GetChild(2).transform.GetChild(1).gameObject.SetActive(true);
    }


}
