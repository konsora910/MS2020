//=============================================
// ゲーム画面上の設定を入れる
//　
//
//=============================================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    // 画面サイズ
    // public static int  GameScreenSize_Width; // 幅
    // public static int  GameScreenSize_Hight; // 高さ
    // public static bool FullScreen;          // フルスクリーンするかしないか
    // public static int  RefreshRate;          //  リフレッシュレート数


    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        // 画面サイズ
        Screen.SetResolution(1920, 1080, false, 60);
    }

    public int ScreenWidth;
    public int ScreenHeight;

    void Awake()
    {
        // PC向けビルドだったらサイズ変更
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
        Application.platform == RuntimePlatform.OSXPlayer ||
        Application.platform == RuntimePlatform.LinuxPlayer)
        {
            Screen.SetResolution(ScreenWidth, ScreenHeight, false);
        }
    }
}
