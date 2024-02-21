using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryPanel : MonoBehaviour
{
    public List<GameObject> panels;
    public Sprite selectedSprite;
    private void Start()
    {
        foreach (GameObject panel in panels)
        {
            PanelClickDetector clickDetector = panel.GetComponent<PanelClickDetector>();
            if (clickDetector == null)
            {
                clickDetector = panel.AddComponent<PanelClickDetector>();
            }

            clickDetector.Initialize(this, panel);
            panel.SetActive(false);
        }
    }

    public void PanelClicked(GameObject clickedPanel)
    {
        Debug.Log("Panel Clicked: " + clickedPanel.name);
        //GameObject temp = new GameObject();
        //temp.transform.parent = clickedPanel.transform;

        //Image img = temp.AddComponent<Image>();
        //img.sprite = selectedSprite;
        clickedPanel.transform.GetChild(0).GetComponentInChildren<Image>().enabled = true;
    }
    private void OnEnable()
    {
        UpdateInventory();
    }

    private void UpdateInventory()
    {
        List<Item> items = Inventory.instance.Items;

        for (int i = 0; i < items.Count && i < panels.Count; i++)
        {
            GameObject p = panels[i];
            p.SetActive(true);
            p.transform.GetChild(0).GetComponentInChildren<Image>().enabled = false;
            p.GetComponent<Image>().sprite = items[i]._info.img;
        }
    }
}
public class PanelClickDetector : MonoBehaviour, IPointerClickHandler
{
    private InventoryPanel inventoryPanel;
    private GameObject associatedPanel;

    public void Initialize(InventoryPanel inventoryPanel, GameObject panel)
    {
        this.inventoryPanel = inventoryPanel;
        this.associatedPanel = panel;
        //panel.GetComponentInChildren<Image>().enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        inventoryPanel.PanelClicked(associatedPanel);
    }
}
