using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class LocalizedText : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        Localizator.OnLanguageChangeDelegate += OnLanguageChanged;
    }

    private void OnDisable()
    {
        Localizator.OnLanguageChangeDelegate -= OnLanguageChanged;
    }


    private void Start()
    {
        Initialize();
    }
    protected abstract void OnLanguageChanged();
    protected abstract void Initialize();
    protected string GetText(string textKey)
    {
        return Localizator.GetText(textKey);
    }

    
}
