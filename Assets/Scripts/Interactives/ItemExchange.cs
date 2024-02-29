using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemExchange : MonoBehaviour
{
    public ItemInfo give;
    public void TakeItem()
    {
        Inventory.instance.Add(give);
        PlayerAnimation.instance.TakeItem(null);
    }
}
