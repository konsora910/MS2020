using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingTask : MonoBehaviour
{
// タスク関係
    public GameObject[] Task; // 料理のタスク 
    // public GameObject[] CookingMat; // 素材
    public int num; // 乱数
    public int MAX_task; // 表示する最大タスク
    int task; // 今のタスク数
// 料理の素材
    GameObject[] food;
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
        // タスクリストの最大表示数がマックスになったら
        if (task >= MAX_task)
        {
            while (true)
            {
                num = Random.Range(0, Task.Length);
                Instantiate(Task[num], transform.position, transform.rotation);
                Debug.Log("生成したタスク:　テスト" + (num + 1));
                task += 1;
                // 10秒停止
                yield return new WaitForSeconds(10);

            }
        }
        ////////////////////////////////////////////////////////////////////
    }
    // 課題をクリアすると今表示したタスクを消す
    void ResultTask()
    {
      //  if()
    }
    void ClearTask()
    {
        // Destroy(task);
    }
}
