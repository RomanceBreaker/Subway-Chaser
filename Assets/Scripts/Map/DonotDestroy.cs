using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonotDestroy : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (GameObject.Find("Canvas").GetComponent<UI_Test_S>().Next == true)
        {
            DontDestroyOnLoad(GameObject.Find("Player").GetComponent<Player_S>().take_item);
        }
    }
}
