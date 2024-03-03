using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceElevatorButton : MonoBehaviour, Usable, Saveable
{
    public GameObject btn;
    private bool inPlace = false;
    public void Load(GameData gameData)
    {
        inPlace = gameData.btnInPlace;
        if (inPlace)
        {
            btn.SetActive(true);
        }
    }

    public void Save(ref GameData gameData)
    {
        gameData.btnInPlace = inPlace;
    }

    public bool Use(GameObject item)
    {
        
        if (item.GetComponent<Item>()._info.nameKey.Equals(Parameter.Str_ElevBtn))
        {
            inPlace = true;
            Destroy(item);
            btn.SetActive(true);
            btn.GetComponent<Item>().InteractPanel.SetActive(false);
            return true;
        }
        return false;
    }

    private void Awake()
    {
        GameManager.instance.AddSaveable(GetComponent<Saveable>());
    }
}
