using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    internal static GameSlot gameSlot;

    void Awake()
    {

        if (instance == null)
        {

            instance = this;
            //GameObject go = new GameObject("GameDataManager");
            //go.AddComponent<DataPersistenceManager>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(Parameter.StartMenu_SCENE);
    }

    internal void SaveData(ref GameData gameData)
    {
        throw new NotImplementedException();
    }

    internal void LoadData(GameData gameData)
    {
        throw new NotImplementedException();
    }
    //Load diferent scene methods
}
