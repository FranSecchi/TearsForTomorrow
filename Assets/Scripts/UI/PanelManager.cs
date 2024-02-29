using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject escapePanel;
    public GameObject inventoryPanel;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Show(escapePanel);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Show(inventoryPanel);
        }
    }
    public void Show(GameObject go)
    {
        if(go != null)
            go.SetActive(!go.activeSelf);
    }
    public void ReturnMenu()
    {
        GameManager.instance.LoadMenu();
    }
}
