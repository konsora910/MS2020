using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceControl : MonoBehaviour
{
    public bool takeout = false;     　  // 持っていない状態を表す
    public Vector3 FoodResetPosition;  　//食べ物の初期位置
    public GameObject copyFood;
    public GameObject Food;
    bool copy = false;
    bool bDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        copy = false;
        copyFood = (GameObject)Resources.Load("rice");
        FoodResetPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (takeout == true)
        {
            //食材を持たれたら元の位置にコピーする
            if (copy == false)
            {
                GameObject obj = GameObject.FindGameObjectWithTag("Food");
                GameObject instance = (GameObject)Instantiate(copyFood, new Vector3(FoodResetPosition.x, FoodResetPosition.y, FoodResetPosition.z), Quaternion.identity);
                instance.transform.parent = obj.transform;          //コピー食材をfoodの子に
                obj.GetComponent<Foodselect1>().AddFood(instance.transform);

            }
            copy = true;
        }

        DestroyFood(bDestroy);
    }
    void OnTriggerStay(Collider Collider)
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            //ゴミ箱と接触していたら
            if (Collider.gameObject.tag == "DustBox")
            {
                bDestroy = true;
            }

            //プレイヤーかAIが食べ物を持ったら
            if (Collider.gameObject.tag == "Player" || Collider.gameObject.tag == "AI")
            {
                takeout = true; // true = 何かしら持っている
            }
        }
    }

    public void DestroyFood(bool delate)
    {
        if (takeout == false && delate == true)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Food");
            obj.GetComponent<Foodselect1>().DelateFood(this.transform);
            Destroy(this.gameObject);
        }
    }

}
