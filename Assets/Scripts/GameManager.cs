using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    internal static GameSlot gameSlot;
    public static GameManager instance = null;

    public Transform player;

    void Awake()
    {

        if (instance == null)
        {

            instance = this;
            GameObject go = new GameObject("GameDataManager");
            go.AddComponent<DataPersistenceManager>();
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
        gameData.position = player.position;
        gameData.rotation = player.forward;
    }

    internal void LoadData(GameData gameData)
    {
        player.position = gameData.position;
        player.forward = gameData.rotation;
    }
    //Load diferent scene methods
}
