using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TakeItem", menuName = "Dialogue/EndConversation/TakeItem", order = 1)]
public class TakeItemNode : EndNode
{
    public ItemInfo item;
    public override void OnChosen(GameObject talker)
    {
        base.OnChosen(talker);
        PlayerAnimation.instance.TakeItem(null);
        Inventory.instance.Add(item);
    }
}
