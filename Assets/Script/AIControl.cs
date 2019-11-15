using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform m_TMT = null;
    [SerializeField]
    private Transform m_Egg = null;
    [SerializeField]
    private Transform m_Rice = null;
    [SerializeField]
    private Transform m_FryingPan = null;
    [SerializeField]
    private Transform m_Pot = null;
    [SerializeField]
    private Transform m_CuttingBoard = null;
    [SerializeField]
    public NavMeshAgent m_navAgent = null;

    private bool FoodHave = false;

    private int CookKind = 0;
    private int FoodKind = 0;
    private void Awake()
    {
        m_navAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {

        StartCoroutine("Neutral");
    }


    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Neutral()
    {
        CookKind = 0;
        FoodKind = 0;
        //待機状態ループ
        while (true)
        {
            //トマト選択中
            if (Input.GetKey("u"))
            {

                if (Input.GetKey("h"))   //まな板
                {
                    StartCoroutine("MoveTMT");
                    CookKind = 1;
                    yield break;
                }
                else if (Input.GetKey("j"))//鍋
                {
                    StartCoroutine("MoveTMT");
                    CookKind = 2;
                    yield break;
                }
                else if (Input.GetKey("k"))//フライパン
                {
                    StartCoroutine("MoveTMT");
                    CookKind = 3;
                    yield break;
                }
            }

            if (Input.GetKey("i"))
            {
                if (Input.GetKey("h"))   //まな板
                {
                    StartCoroutine("MoveEGG");
                    CookKind = 1;
                    yield break;
                }
                else if (Input.GetKey("j"))//鍋
                {
                    StartCoroutine("MoveEGG");
                    CookKind = 2;
                    yield break;
                }
                else if (Input.GetKey("k"))//フライパン
                {
                    StartCoroutine("MoveEGG");
                    CookKind = 3;
                    yield break;
                }

            }
            if (Input.GetKey("o"))
            {
                if (Input.GetKey("h"))   //まな板
                {
                    StartCoroutine("MoveRICE");
                    CookKind = 1;
                    yield break;
                }
                else if (Input.GetKey("j"))//鍋
                {
                    StartCoroutine("MoveRICE");
                    CookKind = 2;
                    yield break;
                }
                else if (Input.GetKey("k"))//フライパン
                {
                    StartCoroutine("MoveRICE");
                    CookKind = 3;
                    yield break;
                }

            }

            //1フレーム停止
            yield return null;
        }



        //ここに再開後の処理を書く
    }

    IEnumerator MoveTMT()
    {
        
        FoodKind = 1;
        while (true)
        {

            if (FoodHave == false)
            {
                if (m_TMT != null)
                {
                    m_navAgent.destination = m_TMT.position;
                }

            }
 
            if (FoodHave == true)
            {
                switch (CookKind)
                {
                    case 1:
                        StartCoroutine("MoveCuttingBoard");
                        break;
                    case 2:
                        StartCoroutine("MovePot");
                        break;
                    case 3:
                        StartCoroutine("MoveFryingPan");

                        break;

                }
                yield return null;
            }
                //フレーム停止
                yield return null;

                //ここに再開後の処理を書く
        }
        
    }

    IEnumerator MoveEGG()
    {
        FoodKind = 2;
        while (true)
        {

            //ここに処理を書く
            if (FoodHave == false)
            {
                if (m_Egg != null)
                {
                    m_navAgent.destination = m_Egg.position;
                }
            }
            if (FoodHave == true)
            {
                switch (CookKind)
                {
                    case 1:
                        StartCoroutine("MoveCuttingBoard");
                        break;
                    case 2:
                        StartCoroutine("MovePot");
                        break;
                    case 3:
                        StartCoroutine("MoveFryingPan");

                        break;

                }
                //1フレーム停止
                yield return null;

                //ここに再開後の処理を書く
            }
            yield return null;
        }
    }
    IEnumerator MoveRICE()
    {
        FoodKind = 3;
        while (true)
        {
            //ここに処理を書く
            if (FoodHave == false)
        {
            if (m_Rice != null)
            {
                m_navAgent.destination = m_Rice.position;
            }
        }
            if (FoodHave == true)
            {
                switch (CookKind)
                {
                    case 1:
                        StartCoroutine("MoveCuttingBoard");
                        break;
                    case 2:
                        StartCoroutine("MovePot");
                        break;
                    case 3:
                        StartCoroutine("MoveFryingPan");

                        break;

                }

                //1フレーム停止
                yield return null;
            }
            //ここに再開後の処理を書く
            yield return null;
        }
    }
    IEnumerator MoveFryingPan()
    {
        while (true)
        {
            //ここに処理を書く
            if (m_FryingPan != null)
        {
            m_navAgent.destination = m_FryingPan.position;
        }
        //1フレーム停止
        yield return null;
    
        //ここに再開後の処理を書く
    }
    IEnumerator MovePot()
    {
        //ここに処理を書く
        if (m_Pot != null)
        {
            m_navAgent.destination = m_Pot.position;
        }
        //1フレーム停止
        yield return null;
    
        //ここに再開後の処理を書く
    }
    IEnumerator MoveCuttingBoard()
    {
        //ここに処理を書く
        if (m_CuttingBoard != null)
        {
            m_navAgent.destination = m_CuttingBoard.position;
        }
        //1フレーム停止
        yield return null;
    }
        //ここに再開後の処理を書く
    }

    void OnTriggerEnter(Collider Collider)
    {// 接触中
        if(FoodKind == 1)
        {
            if (Collider.gameObject.tag == "tmt")
            {
              Debug.Log("とまと");
            }

        }
        if (FoodKind == 2)
        {
            if (Collider.gameObject.tag == "egg")
            {
                Debug.Log("たまご");
            }

        }
        if (FoodKind == 3)
        {
            if (Collider.gameObject.tag == "rice")
            {
                Debug.Log("こめー");
            }

        }

    }
}
