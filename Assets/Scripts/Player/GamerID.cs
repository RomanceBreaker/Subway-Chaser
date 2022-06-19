using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerID : MonoBehaviour
{
    private const string CHARS =
         "0123456789abcdefghijklmnopqrstuvwxyz";

    public static string GetID()
    {
        int length = 6;
        var sb = new System.Text.StringBuilder(length);
        var r = new System.Random();

        for (int i = 0; i < length; i++)
        {
            int pos = r.Next(CHARS.Length);
            char c = CHARS[pos];
            sb.Append(c);
        }

        return sb.ToString();
    }
}
