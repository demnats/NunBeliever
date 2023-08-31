using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerDialogue : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] public Dialogue dialogue;
    [SerializeField] private float waitingTime;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DialogueTrigger"))
        {
            if (!dialogueManager.alreadyTriggered)
            {
                dialogueManager.alreadyTriggered = true;
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
            else { dialogueManager.DisplayNextSentence(); }
            other.gameObject.SetActive(false);

            StartCoroutine(dialogueManager.unloadSentence());
        }
    }
    
}
