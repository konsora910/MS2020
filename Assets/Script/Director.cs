using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    /// <summary>
    /// ゲームモード
    /// </summary>
    public enum Mode
    {
        Title,
        Game,
        GameClear,
        
    }

    /// <summary>現在のゲームモード</summary>
    public Mode CurrentMode { get; private set; }

    private void Start()
    {
        
    }

    private void Update()
    {

    }
}
