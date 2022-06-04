using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpPower = 2f;
    public bool isJumping = false;

 
    public Note note;
    public HPbar hp;
    public Camera mainCamera;
    private Rigidbody rigid;
    private RaycastHit hit;

    private void Start()
    {
        //note = GameObject.FindWithTag("Note").GetComponent<Note>();
        //mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        rigid = GetComponent<Rigidbody>();
        hp.Init();
    }

    private void FixedUpdate()
    {
        Move();     // 항상 앞으로 이동

        if (Input.GetKeyDown(KeyCode.Z))    // 왼쪽 회전
        {
            RotateLeft();
        }
        if (Input.GetKeyDown(KeyCode.C))    // 오른쪽 회전
        {
            RotateRight();
        }
        if (Input.GetKey(KeyCode.A))    // 왼쪽 이동
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))    // 오른쪽 이동
        {
            MoveRight();
        }
        if (Input.GetMouseButtonDown(1))    // 점프 (마우스 우클릭)
        {
            //Jump();
            StartCoroutine(Jump());
        }
        if (Input.GetMouseButtonDown(0))    // 칼 휘둘러서 노트 맞춤 (마우스 좌클릭)
        {
            Brandish();
        }
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

    //private void Jump()
    //{
    //    // 점프 몇 번까지 가능하게 할 지?

    //    if (!isJumping)
    //    {
    //        isJumping = true;
    //        rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    //    }
    //}

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

    private void Brandish()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, transform.forward * 1000, Color.red);

        note.RayCasting(ray);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        if (other.gameObject.CompareTag("Note"))
        {
            Destroy(other.gameObject);

            if (hp.GetDamage() <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        Debug.Log("Die");
    }
}