using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public Note note;
    public Note[] notes = new Note[5];
    //public GameObject[] foods = new GameObject[5];
    public Vector3 startPos;            // ě˛ě ?ě ??spawner position
    public Vector3 currPos;             // update?ë spawner??random position

    public Transform hitTrans;
    public Transform playerTrans;
    public Transform noteParent;        // ?ě´?´ëź?¤ě°˝??clone??note?¤ě ę´ëŚŹí??parent

    private bool canShoot;

    void Start()
    {
        startPos = transform.localPosition;     // 0, 6, 20 ęł ě 
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
        int noteIdx = Random.Range(0, notes.Length);

        Note noteTemp = Instantiate(notes[noteIdx], noteParent);
        noteTemp.Init(currPos, hitTrans.localPosition, playerTrans.eulerAngles);

        yield return new WaitForSeconds(1.0f);      // 1ě´ë§???ěą
        canShoot = true;
    }
}