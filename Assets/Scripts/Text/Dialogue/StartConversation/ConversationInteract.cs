using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationInteract : MonoBehaviour,Interactuable
{
    public Conversation NewConversation;
    public DialogueManager manager;

    public void Interact(bool activate)
    {
        if (activate)
            manager.StartConversation(NewConversation, gameObject);
        else
            manager.FinishConversation();
    }
}
