using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationGiveItem : MonoBehaviour, Usable
{
    public ConversationInteract convo;
    public Conversation newConvo;
    public string itemKey;
    public bool Use(GameObject item)
    {
        if (item.GetComponent<Item>()._info.nameKey.Equals(itemKey))
        {
            convo.NewConversation = newConvo;
            PlayerAnimation.instance.Interact();
            Destroy(item);
            return false;
        }
        return false;
    }
}
