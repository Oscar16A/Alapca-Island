using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class TypeWriterEffect : MonoBehaviour
{
    public List<string> list = new List<string>();
    public float delay = 0.1f;
    public string fullText;
    public string currentText = "";
    public string transitionSceneTitle;

    [Header("Dialogue Stuff")]
    public string[] dialogues;
    public float charDelay;
    private float timeToNextChar;
    private int dialogueIndex = -1;
    private int charIndex = -1;
    public TextMeshProUGUI textbox;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            NextLine();            
        }

        if (dialogueIndex == dialogues.Length) 
        {
            SceneManager.LoadScene(transitionSceneTitle);
        }
    }

    IEnumerator ShowText() 
    {
        for (int i = 0; i < fullText.Length+1; i++) 
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }

    void NextLine() 
    {
        currentText = "";
        dialogueIndex++;
        this.GetComponent<TextMeshProUGUI>().text = currentText;
        fullText = dialogues[dialogueIndex];
        StartCoroutine(ShowText());
    }
}
