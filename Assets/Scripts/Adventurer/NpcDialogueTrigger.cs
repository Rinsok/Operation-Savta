using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class NpcDialogueTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Dialogue dialogue;
    private bool inDialogue = false;
    private DialogueManager dial;
   private SwitchPlayer player;
    private void Start()
    {
        dial = FindAnyObjectByType<DialogueManager>();
       player = FindAnyObjectByType<SwitchPlayer>();
    }

    public void TriggerDialogue()
    {
        dial.StartDialogue(dialogue);
    }

    private void Update()
    {
        if(inDialogue)
        {
            if (Input.anyKeyDown)
            {

                dial.DisplayNextSentence();
                if(dial.noDial)
                {
                    inDialogue = false;
                    gameObject.SetActive(false);
                    player.enableMovement();

                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TriggerDialogue();
            inDialogue = true;
            player.disableMovement();
            
        }



    }
}



