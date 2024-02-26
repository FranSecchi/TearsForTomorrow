using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    public Conversation NewConversation;
    public DialogueManager DialogueManager;
    
    
    private void OnTriggerEnter(Collider other)
    {
        DialogueManager.StartConversation(NewConversation, transform.parent.gameObject);
        PlayerAnimation.instance.Talk(true);
    }
    private void OnTriggerExit(Collider other)
    {
        DialogueManager.FinishConversation();
        PlayerAnimation.instance.Talk(false);
    }

}
