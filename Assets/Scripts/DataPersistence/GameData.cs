using System.Collections;
using System.Collections.Generic;
//using Newtonsoft.Json;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public string currentScene;
    public Vector3 playerPos;
    public Vector3 playerForward;
    public bool cofreOpened;
    public bool elevatorOpen;
    public int epoca;
    public bool btnInPlace;
    public bool btnActive;
    public bool amaOpen;

    //public Vector3 position;
    //public Vector3 rotation;

    public GameData()
    {
        currentScene = Parameter.StartMenu_SCENE;
        playerPos = new Vector3(0, 0, 0);
        playerForward = Vector3.forward;
        cofreOpened = false;
        btnInPlace = false;
        btnActive = false;
        amaOpen = false;
}
}
