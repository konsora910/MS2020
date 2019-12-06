using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    private static Image fadeImage;         //フェードのテクスチャ
    private static float f_alpha = 0.0f;      //フェードのα値
    //フェードインアウトのフラグ
    public static bool b_FadeIn = false;
    public static bool b_FadeOut = false;
    public static bool b_FadeOutEnd = false;
    private static float f_fadeTime = 2.0f;   //フェードの時間（単位は秒
    public static string NextSceneName;

    //フェード用のとテクスチャ生成
    static void Init()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        //フェード用のテクスチャ生成
        fadeImage = new GameObject("ImageFade").AddComponent<Image>();
        fadeImage.transform.SetParent(canvas.transform, false);
        fadeImage.rectTransform.anchoredPosition = Vector3.zero;

        fadeImage.color = Color.black;
        fadeImage.rectTransform.sizeDelta = new Vector2(1000, 1000);
    }

    //フェードイン開始
    public static void FadeIn()
    {
        if (fadeImage == null) Init();
        b_FadeIn = true; 
    }

    //フェードアウト開始
    public static void FadeOut(string name)
    {
        if (fadeImage == null) Init();
        b_FadeOut = true;
        NextSceneName = name;
    }

    void Update()
    {
        if (b_FadeIn)
        {
            //経過時間からα値計算
            f_alpha -= Time.deltaTime / f_fadeTime;

            //フェードイン終了判定
            if (f_alpha <= 0.0f)
            {
                b_FadeIn = false;
                f_alpha = 0.0f;
                
            }
            //フェードのα設定
            fadeImage.color = new Color(0.0f, 0.0f, 0.0f, f_alpha);
        }
        else if (b_FadeOut)
        {
            //経過時間からα値計算
            f_alpha += Time.deltaTime / f_fadeTime;

            //フェードアウト終了判定
            if (f_alpha >= 1.0f)
            {
                b_FadeOut = false;
                f_alpha = 1.0f;
                SceneManager.LoadScene(NextSceneName);
            }

            //フェードのα設定
            fadeImage.color = new Color(0.0f, 0.0f, 0.0f, f_alpha);
        }
    }
}
