using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Note note;
    public Vector3 startPos;        // ó�� ���� �� spawner position
    public Vector3 currPos;       // update�Ǵ� spawner�� random position

    public Transform hitTrans;
    public Transform noteParent;
    public Transform playerTrans;

    private bool canShoot;

    void Start()
    {
        startPos = transform.localPosition;     // 0, 6, 20 ����
        canShoot = true;
    }

    void Update()
    {
        if (canShoot)
        {
            StartCoroutine(ShootNote());
        }
    }

    IEnumerator ShootNote()
    {
        canShoot = false;
        currPos = startPos + new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), 0f);
        //Debug.Log(currPos.position);

        Note noteTemp = Instantiate(note, noteParent);
        noteTemp.Init(currPos, hitTrans.localPosition, playerTrans.eulerAngles);
        
        //Note note = Instantiate(note, currPos.transform.position, currPos.transform.rotation);

        yield return new WaitForSeconds(1.0f);      // 1�ʸ��� ����
        canShoot = true;
    }
}