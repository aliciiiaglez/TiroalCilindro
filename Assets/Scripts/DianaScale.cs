using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianaScale : MonoBehaviour
{
    public void ScaleUp()
    {
        LeanTween.scale(gameObject, Vector3.one * 4f, 0.5f);

    }

    public void ScaleDown()
    {
        LeanTween.scale(gameObject, Vector3.one * 1f, 0.5f);
    }
}
