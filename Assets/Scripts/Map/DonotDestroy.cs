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
        DontDestroyOnLoad(GameObject.Find("Player").GetComponent<Player_S>().take_item);
    }
}
