using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    public string currentText = "";

    void Start() 
    {}

    IEnumerator ShowText() 
    {
        for (int i = 0; i < fullText.Length; i++) 
        {
            currentText = fullText.Substring(0,i);
            this.GetComponent<TextMeshPro>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
