using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{

    [SerializeField] public float Seconds;
    public GameObject timer_object = null;
    public bool b_TimeUp = false;

    // Start is called before the first frame update
    void Start()
    {
        Seconds = 205;
        b_TimeUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Seconds <= 0 && b_TimeUp == false)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("scene");
            obj.gameObject.GetComponent<SceneControl>().FadeOut("ResultScene");
            b_TimeUp = true;
        }
        else if(Seconds > 0)
        {
            Text timer_text;
            timer_text = timer_object.GetComponent<Text>();
            timer_text.text = "" + (int)Seconds;

            Seconds -= Time.deltaTime;
        }

    }
}
