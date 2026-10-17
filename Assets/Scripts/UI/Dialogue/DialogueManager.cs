using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nametext;
    public TextMeshProUGUI dialogueText;
    [SerializeField] private Animator BG;
    public bool noDial = false;
    private Queue <string> sentences;
    public int lineIndex = 0;


    void Start()
    {
        sentences = new Queue <string> ();
        lineIndex = 0;
    }
    public void StartDialogue(Dialogue dialogue)
    {
        noDial = false;
        BG.SetBool("ComingIn", true);
        nametext.text = dialogue.name;
        sentences.Clear();
        
        foreach (string sentece in dialogue.sentences)
        {
            sentences.Enqueue(sentece);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        lineIndex++;
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string Sentence)
    {
        dialogueText.text = "";
        foreach (char letter in Sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    void EndDialogue()
    {
        noDial = true;
        BG.SetBool("ComingIn", false);
        sentences.Clear();
    }


}
