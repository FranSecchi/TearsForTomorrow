using System.Collections;
using System.Collections.Generic;
using FMOD;
using Unity.VisualScripting;
using UnityEngine;

public class ElevatorDoors : MonoBehaviour, Interactuable, Saveable
{
    public Animator _anim;
    private bool open = false;
    // Start is called before the first frame update
    private void Awake()
    {
        GameManager.instance.AddSaveable(GetComponent<Saveable>());
    }
    public Transform getStandPosition()
    {
        return null;
    }

    public void Interact(bool activate)
    {
        if (activate)
        {
            _anim.SetTrigger(open ? "Close" : "Open");
            PlayerAnimation.instance.Interact();
            open = !open;
        }
    }

    public void Load(GameData gameData)
    {
        open = gameData.elevatorOpen;
        bool b = gameData.btnActive;
        gameObject.SetActive(b);
        if(open && b)
            _anim.SetTrigger("Open");
    }

    public void Save(ref GameData gameData)
    {
        gameData.elevatorOpen = open;
        gameData.btnActive = gameObject.activeSelf;
    }
}
