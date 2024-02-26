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

    private void Awake()
    {
        items = new List<ItemInfo>();
        _gm = GameManager.instance;
        if(instance == null) instance = this;
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

    internal void GrabItem(ItemInfo selected)
    {
        currentItem = Instantiate(selected.prefab, objectOnHand);
        PlayerAnimation.instance.GrabItem();
    }
    internal ItemInfo GetGrabbedItem()
    {
        return currentItem.GetComponent<Item>()._info;
    }
}
