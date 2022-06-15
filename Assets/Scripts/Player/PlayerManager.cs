using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int gamerID;
    public int score = 0;
    public float moveSpeed = 5f;
    public float jumpPower = 2f;
    public bool isJumping = false;

    public HPbar hp;
    public Camera mainCamera;
    private Rigidbody rigid;
    private RaycastHit hit;

    private void Start()
    {
        gamerID = Random.Range(-2147483648, 2147483647);
        rigid = GetComponent<Rigidbody>();
        hp.Init();
    }

    private void FixedUpdate()
    {
        Move();     // �׻� ������ �̵�`

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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))    // ���� ȸ��
        {
            RotateLeft();
        }
        if (Input.GetKeyDown(KeyCode.C))    // ������ ȸ��
        {
            RotateRight();
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
        Debug.Log(rigid.rotation);

        rigid.rotation = rigid.rotation * Quaternion.Euler(0f, -90.0f, 0f);

        Debug.Log("-> left : " + rigid.rotation.eulerAngles);
    }

    private void RotateRight()
    {
        Debug.Log(rigid.rotation);

        rigid.rotation = rigid.rotation * Quaternion.Euler(0f, 90.0f, 0f);
        Debug.Log("-> right : " + rigid.rotation.eulerAngles);
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
        
        RayCasting(ray);
    }

    public void RayCasting(Ray ray)
    {
        RaycastHit hitObj;

        if (Physics.Raycast(ray, out hitObj, Mathf.Infinity))
        {
            if (hitObj.collider.tag == "Note")
            {
                Destroy(hitObj.collider.gameObject);
                score += 100;
            }
        }
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
        //Debug.Log("Die");
        PlayerPrefs.SetInt(gamerID.ToString(), score);
        //Debug.Log(gamerID + " : " + score);


        //Debug.Log("Record : " + PlayerPrefs.GetInt(gamerID.ToString()));
        //Time.timeScale = 0;     // �Ͻ�����
        // end UI
    }
}