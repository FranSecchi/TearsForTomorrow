using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        switch (talker.name){
            case "Recepcionista":
                SoundManager.playRecepcionista();
                break;
            case "Propietari":
                SoundManager.playPropietari();
                break;
            case "AmaDeLlaves":
                SoundManager.playAmaLlaves();
                break;
            case "Morta":
                SoundManager.playMorta();
                break;
            case "Jardinero":
                SoundManager.playJardinero();
                break;
        }
    }
}
