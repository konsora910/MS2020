using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conbairobjGenerator : MonoBehaviour
{
    /// <summary>
    /// コンベア上でオブジェクトを生成するときのみ使う
    /// </summary>
    [SerializeField]
    private GameObject m_object = null;
    [SerializeField]
    private float m_time = 2.0f;

    void Start()
    {
        StartCoroutine(Generator(m_time));
    }

    private IEnumerator Generator(float i_time)
    {
        var waitTime = new WaitForSeconds(i_time);
        while (true)
        {
            yield return waitTime;
            Vector3 offset = Vector3.zero;
            offset.x = Random.Range(-4.0f, 4.0f);
            var obj = GameObject.Instantiate(m_object, transform.position + offset, Quaternion.identity) as GameObject;
            obj.SetActive(true);
        }

    }
}
