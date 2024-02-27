using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryPanel : LocalizedText
{
    public List<GameObject> panels;
    public Sprite selectedSprite;
    public GameObject hoverPanel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    private ItemInfo selected;
    private ItemInfo selected2;
    private List<ItemInfo> items;
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
        hoverPanel.SetActive(false);
    }

    public void PanelClicked(GameObject clickedPanel)
    {
        clickedPanel.transform.GetChild(0).GetComponentInChildren<Image>().enabled = true;
        ItemInfo sel = items[panels.IndexOf(clickedPanel)];

        if(sel == selected)
        {
            selected = null;
            clickedPanel.transform.GetChild(0).GetComponentInChildren<Image>().enabled = false;
        }
        else if(sel == selected2)
        {
            selected2 = null;
            clickedPanel.transform.GetChild(0).GetComponentInChildren<Image>().enabled = false;
        }
        else if (selected == null)
            selected = sel;
        else if (selected2 == null)
            selected2 = sel;
    }
    public void Combine()
    {
        if (selected == null || selected2 == null)
            return;
        Inventory.instance.Combine(selected, selected2);
        UpdateInventory();
        selected = null;
        selected2 = null;
    }
    public void Use()
    {
        if (selected != null)
            Inventory.instance.GrabItem(selected);
        gameObject.SetActive(false);
    }
    public void PanelHovered(GameObject hoveredPanel)
    {
        hoverPanel.SetActive(true);
        int index = panels.IndexOf(hoveredPanel);

        if (index >= 0 && index < items.Count)
        {
            descriptionText.text = GetText(items[index].descriptionKey);
            nameText.text = GetText(items[index].nameKey);
        }
    }
    private void OnEnable()
    {
        UpdateInventory();
    }

    private void UpdateInventory()
    {
        items = Inventory.instance.Items;
        GameObject p;
        foreach (GameObject panel in panels)
            panel.SetActive(false);
        for (int i = 0; i < items.Count && i < panels.Count; i++)
        {
            p = panels[i];
            p.SetActive(true);
            p.transform.GetChild(0).GetComponentInChildren<Image>().enabled = false;
            p.GetComponent<Image>().sprite = items[i].img;
        }
    }

    protected override void OnLanguageChanged()
    {
        descriptionText.text = "";
        nameText.text = "";
    }
}
public class PanelClickDetector : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        inventoryPanel.PanelHovered(associatedPanel);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inventoryPanel.nameText.text = "";
        inventoryPanel.descriptionText.text = "";
        inventoryPanel.hoverPanel.SetActive(false);
    }
}
