using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasicText : LocalizedText
{
    public string Key;
    protected TextMeshProUGUI _text;
    void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    protected override void Initialize()
    {
        _text.text = GetText(Key);
    }

    protected override void OnLanguageChanged()
    {
        _text.text = GetText(Key);
    }
}
