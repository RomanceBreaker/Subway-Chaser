using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpPower = 2f;
    public bool isJumping = false;

    private Rigidbody rigid;


    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
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
        if (Input.GetMouseButtonDown(1))    // ���� (���콺 ��Ŭ��)
        {
            Jump();
        }
        if (Input.GetMouseButtonDown(0))    // Į �ֵѷ��� ��Ʈ ���� (���콺 ��Ŭ��)
        {
            Debug.Log("brandish");
            Brandish();
        }
      
    }

    private void Move()
    {
        Debug.Log("Moving");
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

    private void Jump()
    {
        // ���� �� ������ �����ϰ� �� ��?

        if (!isJumping)
        {
            isJumping = true;
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }

    }
    private void Brandish()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}