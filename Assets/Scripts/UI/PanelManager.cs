using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject escapePanel;
    public GameObject inventoryPanel;

    // Start is called before the first frame update
    void Start()
    {
        Show(escapePanel, false);
        Show(inventoryPanel, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Show(escapePanel, !escapePanel.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Show(inventoryPanel, !inventoryPanel.activeSelf);
        }
    }
    void Show(GameObject go, bool b)
    {
        go.SetActive(b);
    }
}
