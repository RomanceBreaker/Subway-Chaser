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
        Move();     // �׻� ������ �̵�

        if (Input.GetKeyDown(KeyCode.Z))    // ���� ȸ��
        {
            RotateLeft();
        }
        if (Input.GetKeyDown(KeyCode.C))    // ������ ȸ��
        {
            RotateRight();
        }
        if (Input.GetKey(KeyCode.A))    // ���� �̵�
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))    // ������ �̵�
        {
            MoveRight();
        }
        if (Input.GetMouseButtonDown(1))    // ���� (���콺 ��Ŭ��)
        {
            //Jump();
            StartCoroutine(Jump());
        }
        if (Input.GetMouseButtonDown(0))    // Į �ֵѷ��� ��Ʈ ���� (���콺 ��Ŭ��)
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
    //    // ���� �� ������ �����ϰ� �� ��?

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