using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    GameObject Player;
    GameObject Timer;
    GameObject PauseUI1;
    GameObject PauseUI2;

    private Image PauseImage;         //フェードのテクスチャ
    private float f_alpha = 0.0f;      //フェードのα値

    private bool b_Pause = false;
    private int n_select = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Timer = GameObject.FindGameObjectWithTag("time");
        PauseUI1 = GameObject.Find("PauseUI1");
        PauseUI2 = GameObject.Find("PauseUI2");

        f_alpha = 0.0f;
        n_select = 0;
        b_Pause = false;

        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        //Pause用のテクスチャ生成
        PauseImage = new GameObject("ImageFade").AddComponent<Image>();
        PauseImage.transform.SetParent(canvas.transform, false);
        PauseImage.rectTransform.anchoredPosition = Vector3.zero;

        PauseImage.color = new Color(0.0f, 0.0f, 0.0f, f_alpha);
        PauseImage.rectTransform.sizeDelta = new Vector2(5000, 5000);


        PauseUI1.GetComponent<RectTransform>().SetAsLastSibling();
        PauseUI2.GetComponent<RectTransform>().SetAsLastSibling();

        PauseUI1.gameObject.SetActive(false);
        PauseUI2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Y) && b_Pause == false)
        {
            PauseUI1.gameObject.SetActive(true);
            PauseUI2.gameObject.SetActive(true);
            Player.GetComponent<Stop>().StopObject();
            Timer.GetComponent<Stop>().StopObject();
            f_alpha = 0.75f;
            b_Pause = true;
        }

        if (b_Pause == true)
            NowPause();

        PauseImage.color = new Color(0.0f, 0.0f, 0.0f, f_alpha);
    }

    void NowPause()
    {
        if(Input.GetKeyDown(KeyCode.W) && n_select == 0)
        {
            n_select = 1;
        }
        if(Input.GetKeyDown(KeyCode.S) && n_select == 1)
        {
            n_select = 0;
        }


        if (n_select == 0)
        {
            PauseUI2.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            PauseUI1.gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        if(n_select == 1)
        {
            PauseUI1.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            PauseUI2.gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }


        if(Input.GetKeyDown(KeyCode.Space) && n_select == 0)
        {
            PauseUI1.gameObject.SetActive(false);
            PauseUI2.gameObject.SetActive(false);
            Player.GetComponent<Stop>().RemoveObject();
            Timer.GetComponent<Stop>().RemoveObject();
            f_alpha = 0.0f;
            b_Pause = false;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && n_select == 1)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("scene");
            obj.gameObject.GetComponent<SceneControl>().FadeOut("TitleScene");
        }

    }
}
