using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    public Conversation NewConversation;
    public DialogueManager DialogueManager;
    public Animator _anim;
    public GameObject talker;
    private void OnTriggerEnter(Collider other)
    {
        DialogueManager.StartConversation(NewConversation, talker);
        PlayerAnimation.instance.Talk(true);
        if (_anim != null)
            _anim.SetBool("Talk", true);
    }
    private void OnTriggerExit(Collider other)
    {
        DialogueManager.FinishConversation();
        PlayerAnimation.instance.Talk(false);
        if (_anim != null)
            _anim.SetBool("Talk", false);
    }

}
