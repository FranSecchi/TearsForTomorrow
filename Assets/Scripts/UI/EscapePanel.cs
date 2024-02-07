using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePanel : MonoBehaviour
{
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panel.activeSelf) Hide();
            else Show();
        }
    }
    void Show()
    {
        panel.SetActive(true);
    }
    void Hide()
    {
        panel.SetActive(false);
    }
}
