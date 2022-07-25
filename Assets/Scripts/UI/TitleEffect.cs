using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleEffect : MonoBehaviour
{
    public TextMeshProUGUI startText;

    private void Start()
    {
        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText()
    {
        while (true)
        {
            startText.text = "";
            yield return new WaitForSeconds(0.5f);
            startText.text = "Press to start...";
            yield return new WaitForSeconds(0.5f);
        }
    }
}

