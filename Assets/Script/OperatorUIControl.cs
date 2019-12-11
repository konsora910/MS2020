using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorUIControl : MonoBehaviour
{
    [SerializeField]
    GameObject Muzzle;
    [SerializeField]
    GameObject Muzzle_E;

    Quaternion rotationMuzzle;
    Quaternion rotationMuzzle_E;
    // Start is called before the first frame update
    void Start()
    {
        //rotationMuzzle = Muzzle.transform.rotation;
        //rotationMuzzle_E = Muzzle_E.transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
       // Muzzle.transform.rotation = rotationMuzzle;
       // Muzzle_E.transform.rotation = rotationMuzzle_E;
        transform.rotation = Camera.main.transform.rotation;

    }
}
