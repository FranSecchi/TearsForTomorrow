using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryPanel : LocalizedText
{
    public List<GameObject> panels;
    public GameObject hoverPanel;
    public GameObject usingItemPanel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI useText;
    private ItemInfo selected;
    private ItemInfo selected2;
    private ItemInfo _using;
    private List<ItemInfo> items;
    private Inventory inventory;
    private void Start()
    {
        inventory = Inventory.instance;
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
        usingItemPanel.SetActive(false);
        hoverPanel.SetActive(false);
        gameObject.SetActive(false);
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
        inventory.Combine(selected, selected2);
        UpdateInventory();
        selected = null;
        selected2 = null;
    }
    public void Use()
    {
        if(_using != null)
        {
            inventory.ReturnItem(_using);
            _using = null;
            usingItemPanel.SetActive(false);
            gameObject.SetActive(false);
            return;
        }
        if (selected != null && _using == null)
        {
            inventory.GrabItem(selected);
            _using = selected;
        }
        gameObject.SetActive(false);
    }
    public void PanelHovered(GameObject hoveredPanel)
    {
        hoverPanel.SetActive(true);
        int index = panels.IndexOf(hoveredPanel);

        if (index >= 0 && index < items.Count)
        {
            descriptionText.text = GetText(items[index].descriptionKey, TextType.Simple);
            nameText.text = GetText(items[index].nameKey, TextType.Simple);
        }
    }
    private void OnEnable()
    {
        selected = null;
        selected2 = null;
        UpdateInventory();
    }
    private void UpdateInventory()
    {
        if (inventory == null)
            return;
        items = inventory.Items;
        GameObject p;
        usingItemPanel.SetActive(false);
        useText.text = GetText("Use", TextType.Simple);
        if (inventory.CurrentItem != null)
        {
            Image im = usingItemPanel.transform.GetChild(1).GetComponent<Image>();
            im.sprite = _using.img;
            usingItemPanel.SetActive(true);
            useText.text = GetText("Unuse", TextType.Simple);
        }
        foreach (GameObject panel in panels)
            panel.SetActive(false);
        for (int i = 0; i < items.Count && i < panels.Count; i++)
        {
            p = panels[i];
            p.SetActive(true);
            p.transform.GetChild(0).GetComponentInChildren<Image>().enabled = false;
            Image im = p.transform.GetChild(2).GetComponent<Image>();
            im.sprite = items[i].img;
            //im.enabled = true;
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
