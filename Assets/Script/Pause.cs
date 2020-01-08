using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    GameObject Player;
    GameObject Player2;
    GameObject Timer;
    GameObject PauseUI;
    GameObject PauseUI1;
    GameObject PauseUI2;

    private Image PauseImage;         //フェードのテクスチャ
    private float f_alpha = 0.0f;      //フェードのα値

    private bool b_Pause = false;
    private bool b_fade = false;
    private bool b_inout = false;
    private int n_select = 0;
    private float f_count = 0.0f;
   
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player2 = GameObject.FindGameObjectWithTag("Player2");
        Timer = GameObject.FindGameObjectWithTag("time");
        PauseUI = GameObject.Find("PauseUI");
        PauseUI1 = GameObject.Find("PauseUI1");
        PauseUI2 = GameObject.Find("PauseUI2");

        PauseUI.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        PauseUI1.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        PauseUI2.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        f_alpha = 0.0f;
        f_count = 0.0f;
        n_select = 0;
        b_inout = false;
        b_Pause = false;
        b_fade = false;

        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        //Pause用のテクスチャ生成
        PauseImage = new GameObject("ImageFade").AddComponent<Image>();
        PauseImage.transform.SetParent(canvas.transform, false);
        PauseImage.rectTransform.anchoredPosition = Vector3.zero;

        PauseImage.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        PauseImage.rectTransform.sizeDelta = new Vector2(5000, 5000);

        PauseUI.GetComponent<RectTransform>().SetAsLastSibling();
        PauseUI1.GetComponent<RectTransform>().SetAsLastSibling();
        PauseUI2.GetComponent<RectTransform>().SetAsLastSibling();

        PauseUI.SetActive(false);
        PauseUI1.SetActive(false);
        PauseUI2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if((Input.GetKeyDown(KeyCode.Y)|| Input.GetButtonDown("Button_START")) && b_Pause == false)
        {
            PauseUI.SetActive(true);
            PauseUI1.SetActive(true);
            PauseUI2.SetActive(true);
            Player.GetComponent<Stop>().StopObject();
            Player2.GetComponent<Stop>().StopObject();
            Timer.GetComponent<Stop>().StopObject();
            b_Pause = true;
            PauseImage.color = new Color(0.0f, 0.0f, 0.0f, 0.75f);
        }

        if (b_Pause == true)
            NowPause();
    }

    void NowPause()
    {
        if (b_inout == false)
            f_count += Time.deltaTime;
        else if (b_inout == true)
            f_count -= Time.deltaTime;

        if(f_count > 0.8f)
        {
            f_count = 0.8f;
            b_inout = true;
        }
        if(f_count < 0.0f)
        {
            f_count = 0.0f;
            b_inout = false;
        }

        if (b_fade == false)
        {
            if ((Input.GetKeyDown(KeyCode.S) || Input.GetButtonDown("Button_b")) && n_select == 0)
            {
                n_select = 1;
            }
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("Button_a")) && n_select == 1)
            {
                n_select = 0;
            }


            if (n_select == 0)
            {
                PauseUI1.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, f_count+0.2f);
                PauseUI2.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
            }
            if (n_select == 1)
            {
                PauseUI2.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, f_count+0.2f);
                PauseUI1.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
            }

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Button_START") )&& n_select == 0)
            {
                PauseUI.SetActive(false);
                PauseUI1.SetActive(false);
                PauseUI2.SetActive(false);
                Player.GetComponent<Stop>().RemoveObject();
                Player2.GetComponent<Stop>().RemoveObject();
                Timer.GetComponent<Stop>().RemoveObject();
                PauseImage.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                f_alpha = 0.0f;
                b_Pause = false;
            }
            else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Button_START")) && n_select == 1)
            {
                b_fade = true;
                GameObject obj = GameObject.FindGameObjectWithTag("scene");
                obj.gameObject.GetComponent<SceneControl>().FadeOut("TitleScene");
            }
        }
    }
}
