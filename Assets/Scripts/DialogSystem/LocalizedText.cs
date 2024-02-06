using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class LocalizedText : MonoBehaviour
{
    private TextMeshProUGUI _text;
    public string TextKey;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Localizator.OnLanguageChangeDelegate += OnLanguageChanged;
    }

    private void OnDisable()
    {
        Localizator.OnLanguageChangeDelegate -= OnLanguageChanged;
    }

    private void OnLanguageChanged()
    {
        SetText();
    }

    void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        Initialize();
    }
    protected abstract void Initialize();
    protected void SetText()
    {
        _text.text = Localizator.GetText(TextKey);
    }

    
}
