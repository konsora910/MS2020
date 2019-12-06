using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{

    [SerializeField] public float Seconds;
    public GameObject timer_object = null;

    // Start is called before the first frame update
    void Start()
    {
        Seconds = 210;
    }

    // Update is called once per frame
    void Update()
    {
        if (Seconds <= 0)
        {
            GameObject scenes = GameObject.FindGameObjectWithTag("scene");
            scenes.GetComponent<SceneControl>().ChangeScene("ResultScene");
        }
        else
        {
            Text timer_text;
            timer_text = timer_object.GetComponent<Text>();
            timer_text.text = "" + (int)Seconds;

            Seconds -= Time.deltaTime;
        }

    }
}
