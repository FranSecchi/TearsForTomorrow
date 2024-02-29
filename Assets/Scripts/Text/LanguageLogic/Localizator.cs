using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Localizator : MonoBehaviour
{

    public static Localizator Instance;

    Dictionary<string, LanguageData> Data;
    private Language _currentLanguage;
    public Language DefaultLanguage;


    public TextAsset DataSheet;
    

    public delegate void LanguageChangeDelegate();
    public static LanguageChangeDelegate OnLanguageChangeDelegate;

    private void Awake()
    {
        Instance = this;
        _currentLanguage = DefaultLanguage;
        ReadSheet();
    }


    public static string GetText(string textKey)
    {
        return Instance.Data[textKey].GetText(Instance._currentLanguage);
    }

    public static void SetLanguage(Language language)
    {
        Instance._currentLanguage = language;
        OnLanguageChangeDelegate?.Invoke();
    }

    void ReadSheet()
    {
        string[] lines = DataSheet.text.Split(new char[]{ '\n'});
        for (int i = 1; i < lines.Length; i++)
        {
            if (lines.Length > 1)
                AddNewDataEntry(lines[i]);
        }
    }

    void AddNewDataEntry(string s)
    {
        //Debug.Log(s);
        string[] t = s.Split(new char[] { ';' });
        var languageData = new LanguageData(t); 
        if (Data == null)
            Data = new Dictionary<string, LanguageData>();
        Data.Add(t[0], languageData);
    }
}
