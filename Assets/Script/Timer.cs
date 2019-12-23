using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//改造禁止
public class Timer : MonoBehaviour
{

    [SerializeField] public float Seconds = 180.9f;
    GameObject Finish;
    public GameObject timer_object = null;
    public bool b_TimeUp = false;
    public bool b_end = false;
    float n_timer = 0;
    float f_count = 0;

    // Start is called before the first frame update
    void Start()
    {
        Seconds = 180.9f;
        n_timer = 0.0f;
        f_count = 0.0f;
        b_end = false;
        b_TimeUp = false;
        Finish = GameObject.Find("Finish");
        Finish.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Finish.SetActive(false);
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Seconds <= 0 && b_TimeUp == false && b_end == true)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.gameObject.GetComponent<Stop>().StopObject();
            GameObject obj = GameObject.FindGameObjectWithTag("scene");
            if (SceneManager.GetActiveScene().name == "SinglePlayScene")
                obj.gameObject.GetComponent<SceneControl>().FadeOut("SPResultScene");
            else if (SceneManager.GetActiveScene().name == "DoublePlayScene")
                obj.gameObject.GetComponent<SceneControl>().FadeOut("DPResultScene");
            b_TimeUp = true;
        }
        else if (Seconds <= 0 && b_end == false) 
        {
            Finish.SetActive(true);
            f_count += Time.deltaTime;
            if(f_count <=0.5f)
            {
                Finish.transform.localScale = new Vector3(30.0f * f_count, 20.0f * f_count, 1.0f);
            }
            if (f_count >= 3.0f)
                b_end = true;
        }
        else if (Seconds > 0)
        {
            Text timer_text;
            timer_text = timer_object.GetComponent<Text>();
            timer_text.text = "" + (int)Seconds;

            n_timer = Time.deltaTime;
            Seconds -= n_timer;
        }

    }
    void Init()
    {
        
    }
}
