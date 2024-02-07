using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    public Conversation NewConversation;
    public DialogueManager manager;
    private void Start()
    {
        StartDialogue();
    }
    private void OnTriggerEnter(Collider other)
    {
        StartDialogue();
    }

    private void StartDialogue()
    {
        Debug.Log("entered");
        manager.StartConversation(NewConversation, gameObject);
    }
}
