using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationInteract : MonoBehaviour,Interactuable
{
    public Conversation NewConversation;
    public DialogueManager DialogueManager;
    public Transform StandPosition;
    public Animator _anim;
    public Transform getStandPosition()
    {
        return StandPosition;
    }

    public void Interact(bool activate)
    {
        if (activate)
            DialogueManager.StartConversation(NewConversation, gameObject);
        else
            DialogueManager.FinishConversation();
        PlayerAnimation.instance.Talk(activate);
        if(_anim != null)
            _anim.SetBool("Talk", activate);
    }
}
