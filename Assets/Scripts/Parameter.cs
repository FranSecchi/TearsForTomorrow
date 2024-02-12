using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Parameter
{
    public const string SAVEFILE_NAME = "_GameData.txt";
    private const string STARTMENU_SCENE = "MainMenu";
    private const string PRESENT_SCENE = "PresentScene";
    public static string StartMenu_SCENE => STARTMENU_SCENE;
    public static string Present_SCENE => PRESENT_SCENE;
}
