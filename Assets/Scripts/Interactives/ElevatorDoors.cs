using System.Collections;
using System.Collections.Generic;
using FMOD;
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
            if(open)SoundManager.playButton();
            _anim.SetTrigger(open ? "Close" : "Open");
            PlayerAnimation.instance.Interact();
            if (!open) SoundManager.playAscensor();
            open = !open;
        }
    }
}
