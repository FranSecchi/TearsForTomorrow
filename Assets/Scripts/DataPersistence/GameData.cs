using System.Collections;
using System.Collections.Generic;
//using Newtonsoft.Json;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public string currentScene;
    //public Vector3 position;
    //public Vector3 rotation;

    public GameData()
    {
        currentScene = Parameter.StartMenu_SCENE;
    }
}
