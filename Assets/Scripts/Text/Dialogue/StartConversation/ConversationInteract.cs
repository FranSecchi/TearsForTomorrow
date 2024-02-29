using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationInteract : MonoBehaviour,Interactuable
{
    public Conversation NewConversation;
    public DialogueManager DialogueManager;
    public Transform StandPosition;
    public GameObject talker;
    public Transform getStandPosition()
    {
        return StandPosition;
    }

    public void Interact(bool activate)
    {
        if (activate)
            DialogueManager.StartConversation(NewConversation, talker);
        else
            DialogueManager.FinishConversation();
        PlayerAnimation.instance.Talk(activate);
        talker.GetComponent<Animator>().SetBool("Talk", activate);
    }
}
