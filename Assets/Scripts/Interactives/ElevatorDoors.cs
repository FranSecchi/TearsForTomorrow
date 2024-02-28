using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoors : MonoBehaviour, Interactuable
{
    public Animator _anim;
    private bool open = false;
    // Start is called before the first frame update

    public Transform getStandPosition()
    {
        return null;
    }

    public void Interact(bool activate)
    {
        if (activate)
        {
            _anim.SetTrigger(open ? "Close" : "Open");
            open = !open;
        }
    }
}
