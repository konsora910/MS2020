using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PotCookGaugeUI : MonoBehaviour
{
    public Image UIobj;

    void Update()
    {
        UIobj.fillAmount += 1.0f / ConstGaugeUI.ConstUI.POT_COOKING_TIME * Time.deltaTime;
      
    }

    
}
