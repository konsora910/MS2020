using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//改造禁止
public class Timer : MonoBehaviour
{

    [SerializeField] public float Seconds = 180.9f;
    public GameObject timer_object = null;
    public bool b_TimeUp = false;
    float n_timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Seconds = 180.9f;
        n_timer = 0;
        b_TimeUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Seconds <= 0 && b_TimeUp == false)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.gameObject.GetComponent<Stop>().StopObject();
            GameObject obj = GameObject.FindGameObjectWithTag("scene");
            if(SceneManager.GetActiveScene().name == "SinglePlayScene")
                obj.gameObject.GetComponent<SceneControl>().FadeOut("SPResultScene");
            else if (SceneManager.GetActiveScene().name == "DoublePlayScene")
                obj.gameObject.GetComponent<SceneControl>().FadeOut("DPResultScene");
            b_TimeUp = true;
        }
        else if(Seconds > 0)
        {
            Text timer_text;
            timer_text = timer_object.GetComponent<Text>();
            timer_text.text = "" + (int)Seconds;

            n_timer = Time.deltaTime;
            Seconds -= n_timer;
        }

    }
}
