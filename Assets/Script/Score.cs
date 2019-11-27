using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;
    public bool b_Score = false;
    public int FoodType = 4;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(b_Score)
        {
            if (FoodType == Foodselect1.OMERICE)
                score += 100;
            else if (FoodType == Foodselect1.RICEBALL)
                score += 150;
            else if (FoodType == Foodselect1.SOUP)
                score += 200;
            b_Score = false;
        }

        Debug.Log(score);
    }

    void OnTriggerStay(Collider Collider)
    {
        if (Collider.gameObject.tag == "Omerice" || Collider.gameObject.tag == "RiceBoll" || Collider.gameObject.tag == "Soup")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Collider.gameObject.tag == "Omerice")
                    FoodType = Foodselect1.OMERICE;
                else if (Collider.gameObject.tag == "RiceBoll")
                    FoodType = Foodselect1.RICEBALL;
                else if (Collider.gameObject.tag == "Soup")
                    FoodType = Foodselect1.SOUP;
                b_Score = true;
            }
        }
    }
}
