using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButtonEvent : MonoBehaviour
{
    public GameObject button;
    public Player_S player;

    public void clickButton()
    {
        player.ReturnMove();
    }
}
