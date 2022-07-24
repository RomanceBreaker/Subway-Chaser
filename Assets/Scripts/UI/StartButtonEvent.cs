using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonEvent : MonoBehaviour
{
    public GameObject button;
    public Canvas canvas;

    public void clickButton()
    {
        canvas.gameObject.SetActive(false);
    }
}
