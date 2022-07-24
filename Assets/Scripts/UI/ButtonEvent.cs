using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public GameObject button;
    public Canvas canvas;

    public void clickButton()
    {
        canvas.gameObject.SetActive(false);
    }
}
