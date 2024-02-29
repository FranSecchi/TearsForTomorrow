using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaMestressa : MonoBehaviour, Usable
{
    public Animator _anim;
    public bool Use(GameObject item)
    {
        if (item.GetComponent<Item>()._info.nameKey.Equals(Parameter.Str_DoorKey))
        {
            Debug.Log("llega");
            OpenDoor();
            Destroy(item);
            return true;
        }
        return false;
    }

    private void OpenDoor()
    {
        _anim.SetTrigger("Open");
    }
}
