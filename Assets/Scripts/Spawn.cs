using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    float timeMin, timeMax;
    [SerializeField]
    GameObject prefabTarget;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateTarget", timeMin, Random.Range(timeMin, timeMax)); 
    }

    // Update is called once per frame
    void CreateTarget()
    {
        Instantiate(prefabTarget, gameObject.transform.position, Quaternion.identity);
    }
}
