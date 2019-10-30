using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [SerializeField] GameObject[] PotArray = new GameObject[3];
    [SerializeField] bool bUse;

    void Start()
    {
        foreach (GameObject i in PotArray)
        {
            PotArray = null;
        }
    }

    void Update()
    {
        if (PotArray[2]==null) { bUse = true; }
        else { bUse = false; }

    }

    void OnTriggerStay(Collider Collider)
    {
        if (bUse)
        {


            if (Collider.gameObject.tag == "egg")
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PotArray[i] != null)
                    {
                        PotArray[i] = Collider.gameObject;
                    }
                }
            }
            if (Collider.gameObject.tag == "tmt")
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PotArray[i] != null)
                    {
                        PotArray[i] = Collider.gameObject;
                    }
                }
            }
            if (Collider.gameObject.tag == "rice")
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PotArray[i] != null)
                    {
                        PotArray[i] = Collider.gameObject;
                    }
                }
            }
        }
    }
}
