using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Title : MonoBehaviour
{
    GameObject SinglePlay;
    GameObject DoublePlay;
    GameObject[] StartObject = new GameObject[2]; 

    int n_Select = 0;
    float n_count = 0;
    float f_alpha = 1.0f;
    bool b_fade = false;
    bool b_start = false;
    bool b_inout = false;

    // Start is called before the first frame update
    void Start()
    {
        b_fade = false;
        b_start = false;
        b_inout = false;
        f_alpha = 1.0f;
        n_Select = 0;
        n_count = 0;
    
        SinglePlay = GameObject.Find("SinglePlay");
        DoublePlay = GameObject.Find("DoublePlay");
        StartObject[0] = GameObject.Find("Start1");
        StartObject[1] = GameObject.Find("Start2");

        DoublePlay.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
        SinglePlay.SetActive(false);
        DoublePlay.SetActive(false);

        StartObject[1].SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Startだけ表示
        if (b_start == false)
        {
            n_count += Time.deltaTime;
            if (n_count > 2.0f)
                n_count = 0.0f;

            if (n_count - 1.0f > 0.0f)
            {
                StartObject[0].SetActive(false);
                StartObject[1].SetActive(true);
            }
            else if (n_count - 1.0f <= 0.0f)
            {
                StartObject[1].SetActive(false);
                StartObject[0].SetActive(true);
            }
            //人数選択画面に遷移
            if (Input.GetKeyDown(KeyCode.Space)|| Input.GetButtonDown("Button_b"))
            {
                b_start = true;
                n_count = 0;
                StartObject[0].SetActive(false);
                StartObject[1].SetActive(false);
                SinglePlay.SetActive(true);
                DoublePlay.SetActive(true);
            }
        }

        //人数選択画面表示
        else if (b_start == true)
        {
            if (b_fade == false)
            {
                if (b_inout == false)
                    f_alpha -= Time.deltaTime;
                else if (b_inout == true)
                    f_alpha += Time.deltaTime;

                if(f_alpha > 0.8f)
                {
                    f_alpha = 0.8f;
                    b_inout = false;
                }
                else if(f_alpha <0.0f)
                {
                    f_alpha = 0.0f;
                    b_inout = true;
                }

                if (n_Select == 0 && Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("Button_b"))
                    n_Select = 1;
                if (n_Select == 1 && Input.GetKeyDown(KeyCode.A))
                    n_Select = 0;

                if (n_Select == 0)
                { 
                    SinglePlay.gameObject.transform.localScale = new Vector3(25.0f, 18.0f, 1.0f);
                    SinglePlay.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, f_alpha+0.2f);
                    DoublePlay.gameObject.transform.localScale = new Vector3(25.0f, 18.0f, 1.5f);
                    DoublePlay.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
                }
                if (n_Select == 1)
                {
                    SinglePlay.gameObject.transform.localScale = new Vector3(25.0f, 18.0f, 1.0f);
                    SinglePlay.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
                    DoublePlay.gameObject.transform.localScale = new Vector3(25.0f, 18.0f, 1.0f);
                    DoublePlay.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, f_alpha+0.2f);
                }
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Button_b"))
                {
                    if (n_Select == 0)
                    {
                        b_fade = true;
                        GameObject obj = GameObject.FindGameObjectWithTag("scene");
                        obj.gameObject.GetComponent<SceneControl>().FadeOut("SinglePlayScene");
                    }
                    if (n_Select == 1)
                    {
                        b_fade = true;
                        GameObject obj = GameObject.FindGameObjectWithTag("scene");
                        obj.gameObject.GetComponent<SceneControl>().FadeOut("DoublePlayScene");
                    }
                }
            }
        }
    }
}
