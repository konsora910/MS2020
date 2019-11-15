using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foodselect1 : MonoBehaviour
{
    public GameObject[] gameObjectArray = new GameObject[50];
    public Vector3[] FoodPosition = new Vector3[50];
    public Quaternion[] FoodRotation = new Quaternion[50];
    public int[] WhichFood = new int[50];
    public int allFood;
    public GameObject clickedGameObject;
    public bool bSave = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

        int count = 0;
        //食材の登録
        foreach (Transform child in transform)
        {
            gameObjectArray[count] = child.gameObject;
            count++;
        }
        allFood = count;

        //タグの登録
        if (!bSave)
        {
            for (int i = 0; i < allFood; i++)
            {
                if (gameObjectArray[i].tag == "tmt")
                    WhichFood[i] = 0;
                else if (gameObjectArray[i].tag == "egg")
                    WhichFood[i] = 1;
                if (gameObjectArray[i].tag == "rice")
                    WhichFood[i] = 2;
            }
            bSave = true;

        }
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < allFood; i++)
        {
            if (WhichFood[i] == 0)
            {
                //プレイヤーがトマトを持っていたら
                if (gameObjectArray[i].GetComponent<TomatoControl>().takeout == true)
                {
                    player.GetComponent<PlayerController>().food = gameObjectArray[i];
                    player.GetComponent<PlayerController>().FoodType = 0;
                }
            }
            if (WhichFood[i] == 1)
            {
                //プレイヤーが卵を持っていたら
                if (gameObjectArray[i].GetComponent<EggControl>().takeout == true)
                {
                    player.GetComponent<PlayerController>().food = gameObjectArray[i];
                    player.GetComponent<PlayerController>().FoodType = 1;
                }
            }
            if (WhichFood[i] == 2)
            {
                //プレイヤーがコメを持っていたら
                if (gameObjectArray[i].GetComponent<RiceControl>().takeout == true)
                {
                    player.GetComponent<PlayerController>().food = gameObjectArray[i];
                    player.GetComponent<PlayerController>().FoodType = 2;
                }
            }
        }
    }

    //食材を追加したときに呼び出す関数
    public void AddFood(Transform addfood)
    {
        gameObjectArray[allFood] = addfood.gameObject;
        if (gameObjectArray[allFood].tag == "tmt")
            WhichFood[allFood] = 0;
        else if (gameObjectArray[allFood].tag == "egg")
            WhichFood[allFood] = 1;
        if (gameObjectArray[allFood].tag == "rice")
            WhichFood[allFood] = 2;
        allFood++;
    }

    //食材を消去する時に呼び出す関数
    public void DelateFood(Transform DelateFood)
    {
        for(int i = 0; i < allFood; i++)
        {
            if(DelateFood == gameObjectArray[i])
            {
                gameObjectArray[i] = gameObjectArray[allFood - 1];
                WhichFood[i] = WhichFood[allFood - 1];
                gameObjectArray[allFood - 1] = null;
                allFood--;
            }
        }
    }
}
