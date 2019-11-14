using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingTask : MonoBehaviour
{

    public GameObject[] Task; // 料理のタスク 

    // public GameObject[] CookingMat; // 素材
    public int num;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GenerateTask"); // コルーチン　料理タスクの生成
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 一定時間たったら料理のタスク生成
   IEnumerator GenerateTask()
    {
        //3秒停止
        yield return new WaitForSeconds(1);
        num = Random.Range(0, Task.Length);
        Instantiate(Task[num], transform.position, transform.rotation);
        Debug.Log("生成したタスク:　テスト" + Task.Length);


    }
}
