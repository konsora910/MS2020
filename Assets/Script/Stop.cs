using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//改造禁止
public class Stop : MonoBehaviour
{
    ScriptControl sc = new ScriptControl();

    public void StopObject()
    {
        sc.Initialize(this);
        sc.Suspend();
    }

    public void RemoveObject()
    {
        sc.Resume();
    }
}
