using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, Interactuable, Collectable
{
    public ItemInfo _info;
    public Camera ViewToClick;
    public GameObject InteractPanel;
    private void Start()
    {
        if(InteractPanel != null)
        {
            InteractPanel.transform.LookAt(InteractPanel.transform.position + ViewToClick.transform.rotation * Vector3.forward,
                    ViewToClick.transform.rotation * Vector3.up);
            InteractPanel.SetActive(false);
        }
    }
    public void Interact(bool activate)
    {
        if (!ViewToClick.enabled)
            return;
        InteractPanel.SetActive(true);
    }

    public void Collect()
    {
        Inventory.instance.Add(_info);
        Destroy(gameObject);
        PlayerAnimation.instance.GrabItem();
    }

    public void Discard()
    {
        throw new System.NotImplementedException();
    }

    public void Use()
    {

    }

    public Transform getStandPosition()
    {
        return null;
    }
}
