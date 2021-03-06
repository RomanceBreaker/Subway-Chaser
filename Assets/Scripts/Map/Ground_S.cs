using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_S : MonoBehaviour
{
    List<GameObject> Ground_List = new List<GameObject>(); //?? List, ?? ?????? ?뵵
    List<GameObject> Trap_List = new List<GameObject>(); //?? List, ?? ?????? ?뵵
    public GameObject[] Ground_Normal;
    public GameObject[] Ground_Turn;
    public GameObject[] Ground_Trap;
    public Material[] Skybox_Mat;
    public Material a;
    public GameObject Plane;
    Quaternion Map_Q;
    bool create;
    public float create_time;
    //public float speed;
    public Animator animator_train;
    bool Ani_end;

    float sky_time;
    int sky_num;
    void Start()
    {
        Debug.Log(GameObject.Find("Sphere").name);
        GameObject.Find("Sphere").transform.position = GameObject.Find("Player_Box").transform
            .GetChild(0).transform.position;
        GameObject.Find("Sphere").transform.parent = GameObject.Find("Player_Box").transform
            .GetChild(0).transform;
        
        Ani_end = false;
        sky_num = 0;
        sky_time = 50f;
        Map_Q = Quaternion.Euler(new Vector3(0,0,0));
        Ground_List.Add(GameObject.Find("Base_10").gameObject);
        create = true;
        // GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
     
        StartCoroutine("Sky_Change", sky_time);
    }

    void Update()
    {
        if (Ani_end == false)
        {
            Debug.Log("false");
            if (animator_train.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                Debug.Log("????!!!");
                GameObject.Find("Train").gameObject.SetActive(false);
                GameObject.Find("Start_Camera").gameObject.SetActive(false);
                GameObject.Find("Player_Box").gameObject.transform.GetChild(0).gameObject.SetActive(true);
                Ani_end = true;
            }
        }
        else
        {
            //Debug.Log("True");
            Create_Ground();
            Remove_Ground();
            Plane_Move();
        }
    }


    void Create_Ground()
    {
        if (create)
        {
            StartCoroutine("Ground_Create", create_time);
            create = false;
        }
    }

    void Remove_Ground()
    {
        if (Ground_List.Count >= 10)
        {

            Destroy(Ground_List[0].gameObject);
            Ground_List.RemoveAt(0);

            Destroy(Trap_List[0].gameObject);
            Trap_List.RemoveAt(0);
        }
        
    }
    IEnumerator Sky_Change(float sky_time) //???? ????
    {
        yield return new WaitForSeconds(sky_time);
        sky_num++;
        if (sky_num >= 5)
            sky_num = 0;
        RenderSettings.skybox = Skybox_Mat[sky_num];

        StartCoroutine("Sky_Change", sky_time);

    }

        IEnumerator Ground_Create(float create_time) //?? ???? ???? ?ڷ?ƾ
    {
   
        yield return new WaitForSeconds(create_time);
        int Straight_or_Turn = Random.Range(0,5);
        float trap_x = Random.Range(-2.5f, 2.5f);
        float trap_z = Random.Range(-2.5f, 2.5f);

        if (Straight_or_Turn < 3) //???? ???̱?
        {

            Debug.Log("Go");
            int Ground_index = Random.Range(0, Ground_Normal.Length);

            if (Map_Q == Quaternion.identity)
            {
                Ground_List.Add(
                    Instantiate(Ground_Normal[Ground_index],
                    new Vector3(Ground_List[Ground_List.Count - 1].transform.GetChild(0).position.x, 0,
                    Ground_List[Ground_List.Count - 1].transform.GetChild(0).position.z + Ground_Normal[Ground_index].transform.GetChild(0).GetComponent<BoxCollider>().size.z),
                    Map_Q));
            }
            else if (Map_Q == Quaternion.Euler(new Vector3(0, -90, 0)))
            {   
                Ground_List.Add(
                    Instantiate(Ground_Normal[Ground_index],
                    new Vector3(Ground_List[Ground_List.Count - 1].transform.GetChild(0).position.x - Ground_Normal[Ground_index].transform.GetChild(0).GetComponent<BoxCollider>().size.z, 0,
                    Ground_List[Ground_List.Count - 1].transform.GetChild(0).position.z),
                    Map_Q));


            }
            else if (Map_Q == Quaternion.Euler(new Vector3(0, 90, 0)))
            {
                Ground_List.Add(
                    Instantiate(Ground_Normal[Ground_index],
                    new Vector3(Ground_List[Ground_List.Count - 1].transform.GetChild(0).position.x + Ground_Normal[Ground_index].transform.GetChild(0).GetComponent<BoxCollider>().size.z, 0,
                    Ground_List[Ground_List.Count - 1].transform.GetChild(0).position.z),
                    Map_Q));
            }
            Trap_List.Add(
            Instantiate(Ground_Trap[Random.Range(0, 4)],
                                    new Vector3(Ground_List[Ground_List.Count - 1].transform.position.x + trap_x, Ground_List[Ground_List.Count - 1].transform.position.y, Ground_List[Ground_List.Count - 1].transform.position.z + trap_z), Map_Q)
            );
        }
        else
        {

            if (Map_Q == Quaternion.identity) //0,0,0 ?? Go?? ????
            {
                int Turn_index = Random.Range(0, 2);
                if (Turn_index == 0) //Go_Left
                {
                    Debug.Log("Go_Left");

                    Ground_List.Add(Instantiate(Ground_Turn[0],
                        new Vector3(Ground_List[Ground_List.Count - 1].transform.GetChild(0).position.x, 0,
                        Ground_List[Ground_List.Count - 1].transform.GetChild(0).position.z + Ground_Turn[0].transform.GetChild(0).GetComponent<BoxCollider>().size.z)
                        , Map_Q));

                    Trap_List.Add(
                    Instantiate(Ground_Trap[Random.Range(0, 4)],
                        new Vector3(Ground_List[Ground_List.Count - 1].transform.position.x + trap_x, Ground_List[Ground_List.Count - 1].transform.position.y, Ground_List[Ground_List.Count - 1].transform.position.z + trap_z), Map_Q)
                    );

                    Map_Q = Quaternion.Euler(new Vector3(0, -90, 0));
                }
                else if (Turn_index == 1) //Go_Right
                {
                    Debug.Log("Go_RIght");

                    Ground_List.Add(Instantiate(Ground_Turn[2],
                        new Vector3(Ground_List[Ground_List.Count - 1].transform.GetChild(0).position.x, 0,
                        Ground_List[Ground_List.Count - 1].transform.GetChild(0).position.z + Ground_Turn[2].transform.GetChild(0).GetComponent<BoxCollider>().size.z)
                        , Map_Q));

                    Trap_List.Add(
                    Instantiate(Ground_Trap[Random.Range(0, 4)],
                        new Vector3(Ground_List[Ground_List.Count - 1].transform.position.x + trap_x, Ground_List[Ground_List.Count - 1].transform.position.y, Ground_List[Ground_List.Count - 1].transform.position.z + trap_z), Map_Q)
                    );

                    Map_Q = Quaternion.Euler(new Vector3(0, 90, 0));
                }

            }

            else if (Map_Q == Quaternion.Euler(new Vector3(0, -90, 0))) //0,-90,0 ??, Left?? ????
            {
                Debug.Log("Left_RIght");
                Ground_List.Add(Instantiate(Ground_Turn[3],
                    new Vector3(Ground_List[Ground_List.Count - 1].transform.GetChild(0).transform.position.x - Ground_Turn[3].transform.GetChild(0).GetComponent<BoxCollider>().size.z,
                    0,
                    Ground_List[Ground_List.Count - 1].transform.GetChild(0).transform.position.z)
                    , Map_Q));

                Trap_List.Add(
                Instantiate(Ground_Trap[Random.Range(0, 4)],
                        new Vector3(Ground_List[Ground_List.Count - 1].transform.position.x + trap_x, Ground_List[Ground_List.Count - 1].transform.position.y, Ground_List[Ground_List.Count - 1].transform.position.z + trap_z), Map_Q)
                );
                Map_Q = Quaternion.Euler(new Vector3(0, 0, 0));

            }
            else if (Map_Q == Quaternion.Euler(new Vector3(0, 90, 0))) //0,-0,0 ??, Right?? ????
            {
                Debug.Log("Right_Left");

                Ground_List.Add(Instantiate(Ground_Turn[4],
                    new Vector3(Ground_List[Ground_List.Count - 1].transform.GetChild(0).transform.position.x + Ground_Turn[4].transform.GetChild(0).GetComponent<BoxCollider>().size.z,
                    0,
                    Ground_List[Ground_List.Count - 1].transform.GetChild(0).transform.position.z)
                    , Map_Q));
                Trap_List.Add(
                Instantiate(Ground_Trap[Random.Range(0, 4)],
                        new Vector3(Ground_List[Ground_List.Count - 1].transform.position.x + trap_x, Ground_List[Ground_List.Count - 1].transform.position.y, Ground_List[Ground_List.Count - 1].transform.position.z + trap_z), Map_Q)
                );
                Map_Q = Quaternion.Euler(new Vector3(0, 0, 0));
            }

        }

        create = true;

    }

    void Plane_Move()
    {
        Plane.transform.position = new Vector3(GameObject.Find("Player").transform.position.x,  -1, GameObject.Find("Player").transform.position.z);
    }
}
