using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI_Test_S : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Run_Again()
    {
        Debug.Log("Run Again");
    }

    public void Back_To_MainMonu()
    {
        Debug.Log("Back_To_MainMonu");
    }

    public void Image_Button()
    {
        if (GameObject.Find("Player").gameObject.transform.GetChild(1).transform.GetChild(0).gameObject.activeSelf == true)
        {
            GameObject.Find("Player").gameObject.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
        }
        else
            GameObject.Find("Player").gameObject.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Lobby_to_Start()
    {
        //DontDestroyOnLoad(GetComponent<Player_S>().take_item);
        SceneManager.LoadScene("Game_Start");
    }
}

