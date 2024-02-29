using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public Transform objectOnHand;
    private GameManager _gm;
    private List<ItemInfo> items;
    private Transform currentItem;
    public List<ItemInfo> Items { get => items; set => items = value; }
    public Transform CurrentItem { get => currentItem; set => currentItem = value; }

    private void Awake()
    {
        if(instance == null) instance = this;
        items = new List<ItemInfo>();
        _gm = GameManager.instance;
    }


    public void Add(ItemInfo item)
    {
        items.Add(item);
    }

    internal bool Combine(ItemInfo selected, ItemInfo selected2)
    {

        if (selected.combination == null || selected2.combination == null) return false;
        if (selected.combination == selected2.combination)
        {
            Add(selected.combination);
            items.Remove(selected);
            items.Remove(selected2);
            return true;
        }
        return false;
    }
    internal ItemInfo GetItem(string nameKey)
    {
        foreach(ItemInfo it in Items)
        {
            if (it.nameKey.Equals(nameKey))
                return it;
        }
        return null;
    }
    internal void GrabItem(ItemInfo selected)
    {
        if (selected.prefab == null)
            return;
        currentItem = Instantiate(selected.prefab);
        currentItem.parent = objectOnHand;
        currentItem.gameObject.SetActive(false);
        items.Remove(selected);
        PlayerAnimation.instance.TakeItem(currentItem);
    }
    internal GameObject GetGrabbedItem()
    {
        return currentItem == null? null : currentItem.gameObject;
    }
    internal void ReturnItem(ItemInfo item)
    {
        PlayerAnimation.instance.TakeItem(null);
        Destroy(currentItem.gameObject);
        currentItem = null;
        Add(item);
    }
}
