using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_S : MonoBehaviour
{
    //public Transform Camera_Pos;
    public float moveSpeed = 1f;
    public float jumpPower = 2f;
    public bool isJumping = false;

    private Rigidbody rigid;
    public GameObject take_item;


    //void Update()
    //{
    //   // Camera_Pos.position  = this.transform.position;

    //    float hAxis = Input.GetAxisRaw("Horizontal");
    //    float vAxis = Input.GetAxisRaw("Vertical");

    //    Vector3 inputDir = new Vector3(hAxis, 0, vAxis).normalized;

    //    charRigidbody.velocity = inputDir * moveSpeed;

    //    if(Input.GetKeyDown(KeyCode.Z)){
    //        this.transform.eulerAngles += new Vector3(0, -90f, 0);
    //    }
    //    if (Input.GetKeyDown(KeyCode.C))
    //    {
    //        this.transform.eulerAngles += new Vector3(0, 90f, 0);
    //    }
    //}

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move();
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveBack();
        }
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(Jump());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            RotateLeft();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            RotateRight();
        }
    }

    public void ReturnMove()
    {
        rigid.MovePosition(new Vector3(10f, 2f, 3f));
    }

    private void Move()
    {
        rigid.MovePosition(rigid.position + transform.forward * moveSpeed);
    }

    private void RotateLeft()
    {
        rigid.rotation = rigid.rotation * Quaternion.Euler(0f, -90.0f, 0f);
    }

    private void RotateRight()
    {
        rigid.rotation = rigid.rotation * Quaternion.Euler(0f, 90.0f, 0f);
    }

    private void MoveLeft()
    {
        rigid.MovePosition(rigid.position - transform.right * moveSpeed);
    }

    private void MoveRight()
    {
        rigid.MovePosition(rigid.position + transform.right * moveSpeed);
    }

    private void MoveBack()
    {
        rigid.MovePosition(rigid.position - transform.forward * moveSpeed);
    }

    IEnumerator Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

            yield return new WaitForSeconds(0.5f);
            isJumping = false;
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
