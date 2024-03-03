using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaMestressa : MonoBehaviour, Usable, Saveable
{
    public Animator _anim;
    public SetCamera_Interact inter;
    private bool open = false;
    private void Awake()
    {
        GameManager.instance.AddSaveable(GetComponent<Saveable>());
    }
    public void Load(GameData gameData)
    {
        open = gameData.amaOpen;
        if (open)
        {
            OpenDoor();
            Destroy(inter);
        }
    }

    public void Save(ref GameData gameData)
    {
        gameData.amaOpen = open;
    }

    public bool Use(GameObject item)
    {
        if (item.GetComponent<Item>()._info.nameKey.Equals(Parameter.Str_DoorKey) && !open)
        {
            OpenDoor();
            Destroy(item);
            Destroy(inter);
            return true;
        }
        return false;
    }

    private void OpenDoor()
    {
        open = true;
        SoundManager.playPorta();
        _anim.SetTrigger("Open");
    }
}
