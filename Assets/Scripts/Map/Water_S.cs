using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_S : MonoBehaviour
{
    public static bool isWater = false;

    [SerializeField] private float waterDrag; 
    [SerializeField] private Color waterColor; //// ³·ÀÇ ¹° ¼Ó Fog »ö±ò
    [SerializeField] private float waterFogDensity;

    private float originDrag;
   // private Color originColor; // ¹° ¹Ù±ù »ö±ò
    private float originFogDensity;

    void Start()
    {
        RenderSettings.fog = true;
     //   originColor = RenderSettings.fogColor;
        originFogDensity = RenderSettings.fogDensity;

        originDrag = 0;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            GetWater(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GetOutWater(other);
        }
    }

    private void GetWater(Collider player_)
    {
        isWater = false;
        player_.transform.GetComponent<Rigidbody>().drag = waterDrag;

        //RenderSettings.fogColor = waterColor;
        RenderSettings.fogDensity = waterFogDensity;
    }

    private void GetOutWater(Collider player_)
    {
        if (isWater)
        {
            isWater = false;
            player_.transform.GetComponent<Rigidbody>().drag = originDrag;
         //   RenderSettings.fogColor = originColor;
            RenderSettings.fogDensity = originFogDensity;
        }
    }

}
