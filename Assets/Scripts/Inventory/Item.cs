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
        InteractPanel.transform.LookAt(InteractPanel.transform.position + ViewToClick.transform.rotation * Vector3.forward,
                ViewToClick.transform.rotation * Vector3.up);
        InteractPanel.SetActive(false);
    }
    public void Interact(bool activate)
    {
        if (!ViewToClick.enabled)
            return;
        InteractPanel.SetActive(true);
    }

    public void Collect()
    {
        Inventory.instance.Add(this);
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false;
        InteractPanel.SetActive(false);
    }

    public void Discard()
    {
        throw new System.NotImplementedException();
    }

    public void Use()
    {
        throw new System.NotImplementedException();
    }

    public Transform getStandPosition()
    {
        return null;
    }
}
