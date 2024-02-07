using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    public Conversation NewConversation;
    public DialogueManager manager;
    
    
    private void OnTriggerEnter(Collider other)
    {
        manager.StartConversation(NewConversation, transform.parent.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        manager.FinishConversation();
    }

}
