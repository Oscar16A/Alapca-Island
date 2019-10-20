using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFade : MonoBehaviour
{
    public Image image;

    void Start() 
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn() 
    {
        for(float i = 0; i <= 1; i += Time.deltaTime) 
        {
            image.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }

    IEnumerator FadeOut() 
    {
        for(float i = 0; i <= 1; i -= Time.deltaTime) 
        {
            image.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
}
