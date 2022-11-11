using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScaleObject : MonoBehaviour
{
    public Material hitMaterial;
    void Update()
    {
        //ccon tablet y con ordenador (0, pq es el bot izquu del ratón, 1 rueda o 2 el bot derech) (TouchPhase.Began/GetMouseButtonDown)
        if ((Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
        {
            Vector3 pos = Input.mousePosition;
            if (Application.platform == RuntimePlatform.Android)
            {
                pos = Input.GetTouch(0).position;
            }

            Ray rayo = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayo, out hitInfo) == true)
            {
                if (hitInfo.collider.tag.Equals("Diana"))
                {
                    GameObject diana = hitInfo.collider.gameObject;
                    //hitInfo.collider.GetComponent<MeshRenderer>().material = hitMaterial;
                    LeanTween.scale(diana, Vector3.one * 4f, 0.5f);

                }
                else 
                {
                    GameObject diana = hitInfo.collider.gameObject;
                    //hitInfo.collider.GetComponent<MeshRenderer>().material = defaultMaterial
                    LeanTween.scale(diana, Vector3.one * 1f, 0.5f);
                }
            }
            
        }
    }

}