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
    public GameObject food;
    public int FoodType = 4;
    private bool carryEnd = false;
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
        if(food == null)
        {
          

        }else
        if (FoodHave == true)
        {
            if (FoodType == 0)
                food.GetComponent<TomatoControl>().transform.position = new Vector3((transform.position.x + m_navAgent.destination.x / 15 ), (1), (transform.position.z + m_navAgent.destination.z / 15));
            else if (FoodType == 1)
                food.GetComponent<EggControl>().transform.position = new Vector3((transform.position.x + m_navAgent.destination.x / 15), (1), (transform.position.z + m_navAgent.destination.z / 15));
            else if (FoodType == 2)
                food.GetComponent<RiceControl>().transform.position = new Vector3((transform.position.x + m_navAgent.destination.x / 15), (1), (transform.position.z + m_navAgent.destination.z / 15));

        }
        

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
                    FoodKind = 1;
                    yield break;
                }
                else if (Input.GetKey("j"))//鍋
                {
                    StartCoroutine("MoveTMT");
                    CookKind = 2;
                    FoodKind = 1;
                    yield break;
                }
                else if (Input.GetKey("k"))//フライパン
                {
                    StartCoroutine("MoveTMT");
                    CookKind = 3;
                    FoodKind = 1;
                    yield break;
                }
            }

            if (Input.GetKey("i"))
            {
                if (Input.GetKey("h"))   //まな板
                {
                    StartCoroutine("MoveEGG");
                    CookKind = 1;
                    FoodKind = 2;
                    yield break;
                }
                else if (Input.GetKey("j"))//鍋
                {
                    StartCoroutine("MoveEGG");
                    CookKind = 2;
                    FoodKind = 2;
                    yield break;
                }
                else if (Input.GetKey("k"))//フライパン
                {
                    StartCoroutine("MoveEGG");
                    CookKind = 3;
                    FoodKind = 2;
                    yield break;
                }

            }
            if (Input.GetKey("o"))
            {
                if (Input.GetKey("h"))   //まな板
                {
                    StartCoroutine("MoveRICE");
                    CookKind = 1;
                    FoodKind = 3;
                    yield break;
                }
                else if (Input.GetKey("j"))//鍋
                {
                    StartCoroutine("MoveRICE");
                    CookKind = 2;
                    FoodKind = 3;
                    yield break;
                }
                else if (Input.GetKey("k"))//フライパン
                {
                    StartCoroutine("MoveRICE");
                    CookKind = 3;
                    FoodKind = 3;
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
        
       
        while (true)
        {
            FoodKind = 1;

            if (FoodHave== false)
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
                        FoodKind = 1;
                        yield break;
                    
                    case 2:
                        StartCoroutine("MovePot");
                        FoodKind = 1;
                        yield break;
                      
                    case 3:
                        StartCoroutine("MoveFryingPan");
                        FoodKind = 1;
                        yield break;
                      

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
       
        while (true)
        {
            FoodKind = 2;
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
                        yield break; ;
                    case 2:
                        StartCoroutine("MovePot");
                        yield break;
                    case 3:
                        StartCoroutine("MoveFryingPan");

                        yield break;

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
       
        while (true)
        {
            FoodKind = 3;
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
                        yield break;
                    case 2:
                        StartCoroutine("MovePot");
                        yield break;
                    case 3:
                        StartCoroutine("MoveFryingPan");

                        yield break;

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
            if(carryEnd == true)
            {
                Debug.Log(carryEnd);
                //StartCoroutine("Neutral");
                yield break;
            }
            //1フレーム停止
            yield return null;

            //ここに再開後の処理を書く
        }
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
    IEnumerator Carry()
    {
        yield return new WaitForSeconds(1);
      //  switch (FoodKind)
      //  {
      //      case 1:
      //          food.GetComponent<TomatoControl>().takeout = false;
      //          break;
      //      case 2:
      //          food.GetComponent<EggControl>().takeout = false;
      //          break;
      //      case 3:
      //          food.GetComponent<RiceControl>().takeout = false;
      //          break;
      //  }
      
        FoodHave = false;
        food = null;
        FoodKind = 0;
        CookKind = 0;
        StartCoroutine("Neutral");
        yield break;

    }

    void OnTriggerEnter(Collider Collider)
    {// 接触中

            if (Collider.gameObject.tag == "tmt" && FoodKind ==1)
            { //持つ
                if (FoodHave == false)
                {
                    FoodHave = true;
                    food = Collider.gameObject;
                    if (Collider.gameObject.tag == "tmt")
                        FoodType = 0;
                    if (Collider.gameObject.tag == "egg")
                        FoodType = 1;
                    if (Collider.gameObject.tag == "rice")
                        FoodType = 2;
                }
            }
            if (Collider.gameObject.tag == "egg" && FoodKind == 2)
            { //持つ
                if (FoodHave == false)
                {
                    FoodHave = true;
                    food = Collider.gameObject;
                    if (Collider.gameObject.tag == "tmt")
                        FoodType = 0;
                    if (Collider.gameObject.tag == "egg")
                        FoodType = 1;
                    if (Collider.gameObject.tag == "rice")
                        FoodType = 2;
                }
            }


            if (Collider.gameObject.tag == "rice" && FoodKind ==3)
            { //持つ
                if (FoodHave == false)
                {
                    FoodHave = true;
                    food = Collider.gameObject;
                    if (Collider.gameObject.tag == "tmt")
                        FoodType = 0;
                    if (Collider.gameObject.tag == "egg")
                        FoodType = 1;
                    if (Collider.gameObject.tag == "rice")
                        FoodType = 2;
                }
            }


            if (Collider.gameObject.tag == ("FP") && CookKind ==3)
            {
             StartCoroutine("Carry");

            }

      
        //if (Collider.gameObject.tag == ("pot"))
        //{
        //    if (Input.GetKeyDown(KeyCode.B) && bFood_Take == true)
        //    {
        //        food.GetComponent<FoodController>().takeout = false;
        //        bFood_Take = false;
        //        PotScript.SetFood(food);
        //    }
        //}

    }

    public bool TmtHave()
    {
        bool Check = false;
        if(FoodKind == 1)
        {
            Check = true;
        }
        return Check;
    }
    public bool RiceHave()
    {
        bool Check = false;
        if (FoodKind == 3)
        {
            Check = true;
        }
        return Check;
    }
    public bool EggHave()
    {
        bool Check = false;
        if (FoodKind == 2)
        {
            Check = true;
        }
        return Check;
    }

}
