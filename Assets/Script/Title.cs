using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    GameObject SinglePlay;
    GameObject DoublePlay;

    int n_Select = 0;

    // Start is called before the first frame update
    void Start()
    {
        n_Select = 0;
    
        SinglePlay = GameObject.Find("SinglePlay");
        DoublePlay = GameObject.Find("DoublePlay");

        SinglePlay.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (n_Select == 0 && Input.GetKeyDown(KeyCode.S))
        {
            n_Select = 1;
            SinglePlay.gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            DoublePlay.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (n_Select == 1 && Input.GetKeyDown(KeyCode.W))
        {
            n_Select = 0;
            SinglePlay.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            DoublePlay.gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (n_Select == 0)
            {
                GameObject obj = GameObject.FindGameObjectWithTag("scene");
                obj.gameObject.GetComponent<SceneControl>().FadeOut("TestScene");
            }
            if (n_Select == 1)
            {
                GameObject obj = GameObject.FindGameObjectWithTag("scene");
                obj.gameObject.GetComponent<SceneControl>().FadeOut("TestScene");
            }
        }
    }
}
