using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    //public string ID;
    //public int score = 0;
    public float moveSpeed = 5f;
    public float jumpPower = 2f;
    public bool isJumping = false;

    public HPbar hp;
    public Score scoreText;
    //public Ranking ranking;
    public GameObject scoreBox;
    public Camera mainCamera;
    //public SettingID settingID;
    private Rigidbody rigid;
    private RaycastHit hit;
    public AudioSource attack_a;
    public AudioSource swing_a;
    
    private void Start()
    {
        IDmanager.ID = SettingID.GetID();
        Debug.Log(IDmanager.ID);

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
                IDmanager.score += 100;
                scoreText.UpdateScore(IDmanager.score);
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

        if (other.gameObject.CompareTag("Water"))
        {
            Debug.Log("Water!");
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Die");
        //SceneManager.LoadScene("Ranking");
        scoreBox.SetActive(true);
        
        //Time.timeScale = 0;
        // end UI
    }
}