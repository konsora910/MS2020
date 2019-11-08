using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponePoint : MonoBehaviour
{
    public GameObject copyFood;
    public GameObject Food;
    bool takeout = false;
    bool AItakeout = false;
    bool copy = false;
    // Start is called before the first frame update
    void Start()
    {
        takeout = false;
        copyFood = (GameObject)Resources.Load("tomato");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (takeout == true)
        {
            if (copy == false)
            {
                GameObject instance = (GameObject)Instantiate(copyFood, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            }
            copy = true;
        }
    }
    void OnTriggerStay(Collider Collider)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //プレイヤーと接触していたら
            if (Collider.gameObject.tag == "Player")
            {
                takeout = true; // true = 何かしら持っている
            }
        }

        if (Collider.gameObject.tag == "AI")
        {
            AItakeout = true;
        }
    }
}
