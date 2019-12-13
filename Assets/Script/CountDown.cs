using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    GameObject player;
    GameObject Timer;

    GameObject Count1;
    GameObject Count2;
    GameObject Count3;
    GameObject Countstart;

    public static float UISize = 5.0f;

    private Image PauseImage;         //フェードのテクスチャ

    bool b_CountStart = false;
    float n_Count = 4.0f;
    float n_FontSize = 1.0f;
    float f_alpha = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        //Pause用のテクスチャ生成
        PauseImage = new GameObject("ImageFade").AddComponent<Image>();
        PauseImage.transform.SetParent(canvas.transform, false);
        PauseImage.rectTransform.anchoredPosition = Vector3.zero;

        PauseImage.color = new Color(0.0f, 0.0f, 0.0f, f_alpha);
        PauseImage.rectTransform.sizeDelta = new Vector2(5000, 5000);

        //カウントダウンの画像の初期設定
        Count1 = GameObject.Find("count1");
        Count1.GetComponent<RectTransform>().SetAsLastSibling();
        Count1.gameObject.SetActive(false);

        Count2 = GameObject.Find("count2");
        Count2.GetComponent<RectTransform>().SetAsLastSibling();
        Count2.gameObject.SetActive(false);

        Count3 = GameObject.Find("count3");
        Count3.GetComponent<RectTransform>().SetAsLastSibling();
        Count3.gameObject.SetActive(false);

        Countstart = GameObject.Find("countstart");
        Countstart.GetComponent<RectTransform>().SetAsLastSibling();
        Countstart.gameObject.SetActive(false);

        n_Count = 4.0f;
        b_CountStart = false;
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(b_CountStart)
        {
            n_Count -= Time.deltaTime;
            n_FontSize -= Time.deltaTime;

            if (n_FontSize < 0)
                n_FontSize = 0.0f;

            //いい感じにテクスチャ小さくする
            if(n_Count > 3.0f && n_Count <= 3.33f)
            {
                Count3.gameObject.transform.localScale = new Vector3(UISize * (n_FontSize * 3), UISize * (n_FontSize * 3), 1.0f);
            }
            else if (n_Count > 2.0f && n_Count <= 2.33f)
            {
                Count2.gameObject.transform.localScale = new Vector3(UISize * (n_FontSize * 3), UISize * (n_FontSize * 3), 1.0f);
            }
            else if (n_Count > 1.0f && n_Count <= 1.33f)
            {
                Count1.gameObject.transform.localScale = new Vector3(UISize * (n_FontSize * 3), UISize * (n_FontSize * 3), 1.0f);
            }

            //1秒ごとにテクスチャ切り替え
            if (n_Count <= 3.0f && n_Count > 2.0f && n_FontSize == 0.0f)
            {
                Count3.SetActive(false);
                Count2.SetActive(true);
            }
            else if (n_Count <= 2.0f && n_Count > 1.0f && n_FontSize == 0.0f)
            {
                Count2.SetActive(false);
                Count1.SetActive(true);
            }
            else if (n_Count <= 1.0f && n_Count > 0.0f && n_FontSize == 0.0f)
            {
                Count1.SetActive(false);
                Countstart.SetActive(true);
            }


            if (n_Count <= 0)
            {
                Countstart.SetActive(false);
                player.gameObject.GetComponent<Stop>().RemoveObject();
                Timer.gameObject.GetComponent<Stop>().RemoveObject();
                PauseImage.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                this.gameObject.SetActive(false);
            }
            if (n_FontSize == 0)
                n_FontSize = 1.0f;
        }

        
    }

    void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Timer = GameObject.FindGameObjectWithTag("time");

        player.gameObject.GetComponent<Stop>().StopObject();
        Timer.gameObject.GetComponent<Stop>().StopObject();

    }
    public void CountStart()
    {
        b_CountStart = true;
        Count3.SetActive(true);
    }
}

