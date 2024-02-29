using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaMestressa : MonoBehaviour, Usable
{
    public Animator _anim;
    public SetCamera_Interact inter;
    public bool Use(GameObject item)
    {
        if (item.GetComponent<Item>()._info.nameKey.Equals(Parameter.Str_DoorKey))
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
        _anim.SetTrigger("Open");
    }
}
