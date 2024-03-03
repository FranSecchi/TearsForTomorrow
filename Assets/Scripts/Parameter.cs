using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Parameter
{
    public const string SAVEFILE_NAME = "_GameData.txt";
    private const string STARTMENU_SCENE = "MainMenu";
    private const string PRESENT_SCENE = "PresentScene";
    private const string COFRE_KEY = "nStatue";
    private const string ELEVATOR_BTN = "nElevatorBtn";
    private const string DOOR_KEY = "nKey";
    private const string POLAROID_KEY = "nPolaroid";
    public static string StartMenu_SCENE => STARTMENU_SCENE;
    public static string Present_SCENE => PRESENT_SCENE;
    public static string Str_CofreKey => COFRE_KEY;
    public static string Str_ElevBtn => ELEVATOR_BTN;
    public static string Str_DoorKey => DOOR_KEY;
    public static string Str_Polaroid => POLAROID_KEY;
}
