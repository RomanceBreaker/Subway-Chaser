using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_S : MonoBehaviour
{
    //public Transform Camera_Pos;
    public float moveSpeed;
    private Rigidbody charRigidbody;
    public GameObject take_item;
    void Start()
    {
        charRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
       // Camera_Pos.position  = this.transform.position;

        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Vector3 inputDir = new Vector3(hAxis, 0, vAxis).normalized;

        charRigidbody.velocity = inputDir * moveSpeed;

        if(Input.GetKeyDown(KeyCode.Z)){
            this.transform.eulerAngles += new Vector3(0, -90f, 0);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            this.transform.eulerAngles += new Vector3(0, 90f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "A")
        {
            Debug.Log(other.gameObject.name);
            take_item = other.gameObject;
        }
        else if(other.gameObject.tag == "B")
        {
            Debug.Log(other.gameObject.name);
            take_item = other.gameObject;
        }
    }

}
