using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour, Usable
{
    public ItemInfo llibreta; 
    public ItemInfo espelma;
    public GameObject inventory;
    public bool Use(GameObject item)
    {
        if (item.GetComponent<Item>()._info.nameKey.Equals(Parameter.Str_CofreKey))
        {
            OpenCofre();
            return true;
        }
        return false;
    }
    private void OpenCofre()
    {
        Inventory.instance.Add(llibreta);
        Inventory.instance.Add(espelma);
        inventory.SetActive(true);
    }
}
