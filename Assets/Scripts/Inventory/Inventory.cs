using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    private GameManager _gm;
    private List<Item> items;

    public List<Item> Items { get => items; set => items = value; }

    private void Awake()
    {
        items = new List<Item>();
        _gm = GameManager.instance;
        if(instance == null) instance = this;
    }


    public void Add(Item item)
    {
        items.Add(item);
    }

}
