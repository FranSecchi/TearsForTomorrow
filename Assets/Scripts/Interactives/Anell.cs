using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anell : MonoBehaviour, Usable, Saveable
{
    public ItemInfo anell;
    public GameObject inventory;
    private bool taken = false;
    public void Load(GameData gameData)
    {
        taken = gameData.anellTaken;
        if (taken)
        {
            Inventory.instance.Add(anell);
            gameObject.SetActive(false);
        }
    }

    public void Save(ref GameData gameData)
    {
        gameData.anellTaken = taken;
    }

    public bool Use(GameObject item)
    {
        if (item.GetComponent<Item>()._info.nameKey.Equals(Parameter.Str_Agulla) && !taken)
        {
            taken = true;
            Inventory.instance.Add(anell);
            inventory.SetActive(true);
            gameObject.SetActive(false);
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
