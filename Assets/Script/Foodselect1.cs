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

    public static readonly int TOMATO = 0;
    public static readonly int EGG = 1;
    public static readonly int RICE = 2;
    public static readonly int OMERICE = 3;
    public static readonly int SOUP = 4;
    public static readonly int RICEBALL = 5;
    public static readonly int FOODNULL = 10;

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
                    WhichFood[i] = TOMATO;
                else if (gameObjectArray[i].tag == "egg")
                    WhichFood[i] = EGG;
                if (gameObjectArray[i].tag == "rice")
                    WhichFood[i] = RICE;
            }
            bSave = true;

        }
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
     
    }

    //食材を追加したときに呼び出す関数
    public void AddFood(Transform addfood)
    {
        gameObjectArray[allFood] = addfood.gameObject;
        if (gameObjectArray[allFood].tag == "tmt")
            WhichFood[allFood] = TOMATO;
        else if (gameObjectArray[allFood].tag == "egg")
            WhichFood[allFood] = EGG;
        else if (gameObjectArray[allFood].tag == "rice")
            WhichFood[allFood] = RICE;
        else if (gameObjectArray[allFood].tag == "Omerice")
            WhichFood[allFood] = OMERICE;
        else if (gameObjectArray[allFood].tag == "Soup")
            WhichFood[allFood] = SOUP;
        else if (gameObjectArray[allFood].tag == "RiceBoll")
            WhichFood[allFood] = RICEBALL;
        allFood++;
    }

    //食材を消去する時に呼び出す関数
    public void DelateFood(Transform DelateFood)
    {
        for(int i = 0; i < allFood; i++)
        {
            //配列の最後の食材を消そうとしたら
            if(DelateFood == gameObjectArray[allFood-1].gameObject.transform)
            {
                gameObjectArray[allFood-1] = null;
                WhichFood[allFood - 1] = FOODNULL;
                allFood--;
                break;
            }

            //配列の最後以外の食材を消そうとしたら
            if (DelateFood == gameObjectArray[i].gameObject.transform)
            {
                gameObjectArray[i] = null;
                gameObjectArray[i] = gameObjectArray[allFood - 1];
                WhichFood[i] = WhichFood[allFood - 1];
                gameObjectArray[allFood - 1] = null;
                WhichFood[allFood - 1] = FOODNULL;
                allFood--;
                break;
            }
        }
    }
}
