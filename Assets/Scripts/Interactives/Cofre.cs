using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour, Usable, Saveable
{
    public ItemInfo llibreta; 
    public ItemInfo espelma;
    public GameObject inventory;
    private bool opened = false;
    private void Awake()
    {
        GameManager.instance.AddSaveable(GetComponent<Saveable>());
    }
    public void Load(GameData gameData)
    {
        opened = gameData.cofreOpened;
        if (opened)
        {
            OpenCofre();
            inventory.SetActive(false);
        }
    }

    public void Save(ref GameData gameData)
    {
        gameData.cofreOpened = opened;
    }

    public bool Use(GameObject item)
    {
        if (item.GetComponent<Item>()._info.nameKey.Equals(Parameter.Str_CofreKey) && !opened)
        {
            OpenCofre();
            return true;
        }
        return false;
    }
    private void OpenCofre()
    {
        opened = true;
        Inventory.instance.Add(llibreta);
        Inventory.instance.Add(espelma);
        inventory.SetActive(true);
        SoundManager.playCofre();
    }
}
