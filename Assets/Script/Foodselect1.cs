using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foodselect1 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] gameObjectArray = null;
    //private GameObject[] gameObjectArray = new GameObject[50];
    [SerializeField]
    public Vector3[] FoodPosition = null;
    //public Vector3[] FoodPosition = new Vector3[50];
    [SerializeField]
    public Quaternion[] FoodRotation = null;
    //public Quaternion[] FoodRotation = new Quaternion[50];
    public int allFood;
    public int allFood2;
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
                FoodPosition[i] = gameObjectArray[i].transform.position;
                FoodRotation[i] = gameObjectArray[i].transform.rotation;
            }
            allFood2 = allFood;
            bSave = true;

        }
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < allFood; i++)
        {
            if (gameObjectArray[i].GetComponent<FoodController>().takeout == true)
            {
                player.GetComponent<PlayerController>().food = gameObjectArray[i];
            }
        }
    }
}
