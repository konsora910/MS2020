using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foodselect1 : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField]
    private GameObject[] gameObjectArray = null;
    //private GameObject[] gameObjectArray = new GameObject[50];
    [SerializeField]
    public Vector3[] FoodPosition = null;
    //public Vector3[] FoodPosition = new Vector3[50];
    [SerializeField]
    public Quaternion[] FoodRotation = null;
    //public Quaternion[] FoodRotation = new Quaternion[50];
=======
    public GameObject[] gameObjectArray = new GameObject[50];
    public Vector3[] FoodPosition = new Vector3[50];
    public Quaternion[] FoodRotation = new Quaternion[50];
    public int[] WhichFood = new int[50];
>>>>>>> test2
    public int allFood;
    public GameObject clickedGameObject;
    public bool bSave = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

        int count = 0;
        foreach (Transform child in transform)
        {
            gameObjectArray[count] = child.gameObject;
            count++;
        }
        allFood = count;

        if (!bSave)
        {

            //gameObjectArray2 = gameObjectArray;
            for (int i = 0; i < allFood; i++)
            {
             //   FoodPosition[i] = gameObjectArray[i].transform.position;
             //   FoodRotation[i] = gameObjectArray[i].transform.rotation;

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
                if (gameObjectArray[i].GetComponent<TomatoControl>().takeout == true)
                {
                    player.GetComponent<PlayerController>().food = gameObjectArray[i];
                    player.GetComponent<PlayerController>().FoodType = 0;
                }
            }
            if (WhichFood[i] == 1)
            {
                if (gameObjectArray[i].GetComponent<EggControl>().takeout == true)
                {
                    player.GetComponent<PlayerController>().food = gameObjectArray[i];
                    player.GetComponent<PlayerController>().FoodType = 1;
                }
            }
            if (WhichFood[i] == 2)
            {
                if (gameObjectArray[i].GetComponent<RiceControl>().takeout == true)
                {
                    player.GetComponent<PlayerController>().food = gameObjectArray[i];
                    player.GetComponent<PlayerController>().FoodType = 2;
                }
            }
        }
    }

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
}
