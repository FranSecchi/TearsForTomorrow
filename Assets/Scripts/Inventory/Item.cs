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
        if(InteractPanel != null && ViewToClick != null)
        {
            InteractPanel.transform.LookAt(InteractPanel.transform.position + ViewToClick.transform.rotation * Vector3.forward,
                    ViewToClick.transform.rotation * Vector3.up);
            InteractPanel.GetComponent<Canvas>().worldCamera = ViewToClick;
            InteractPanel.SetActive(false);
        }
    }
    private void OnEnable()
    {
        InteractPanel.SetActive(false);
    }
    public void Interact(bool activate)
    {
        if (ViewToClick != null && !ViewToClick.enabled)
            return;
        InteractPanel.SetActive(activate);
    }
    public void Collect()
    {
        Inventory.instance.Add(_info);
        _info.prefab = transform;
        PlayerAnimation.instance.TakeItem(null);
        gameObject.SetActive(false);
    }
    public void Discard()
    {
        throw new System.NotImplementedException();
    }
    public Transform getStandPosition()
    {
        return null;
    }
}
