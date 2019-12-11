using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
