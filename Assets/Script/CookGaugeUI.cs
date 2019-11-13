using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CookGaugeUI : MonoBehaviour
{
    public Image UIobj;
    public bool roop;
    public float countTime = 5.0f;
    

    void Update()
    {
        if (roop)
        {
            UIobj.fillAmount -= 1.0f / countTime * Time.deltaTime;
        }
    }
}
