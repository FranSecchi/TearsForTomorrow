using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameSlot
{
    Slot1 = 0,
    Slot2 = 1,
    Slot3 = 2
}
public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager instance = null;

    private GameManager gm;
    private FileDataHandler dataHandler;
    private GameData gameData;
    private string fileName = Parameter.SAVEFILE_NAME;

    public GameData GameData { get => gameData; set => gameData = value; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        gm = GameManager.instance;
        this.dataHandler = new FileDataHandler(Application.persistentDataPath);
    }

    public bool isEmpty(GameSlot gameSlot)
    {
        string name = gameSlot + fileName;
        GameData data = dataHandler.Load(name);
        return data == null;
    }

    public void NewGame(GameSlot gameSlot)
    {
        gameData = new GameData();
        SaveGame(gameSlot);
    }
    public void LoadGame(GameSlot gameSlot)
    {
        GameManager.gameSlot = gameSlot;
        string name = gameSlot + fileName;
        gameData = dataHandler.Load(name);
        if (gameData == null)
        {
            NewGame(gameSlot);
        }
        gm.LoadData(gameData);

    }
    public void SaveGame(GameSlot gameSlot)
    {
        if (gameData == null)
        {
            NewGame(gameSlot);
        }
        gm.SaveData(ref gameData);
        string name = gameSlot + fileName;
        dataHandler.Save(gameData, name);
    }
    private void OnApplicationQuit()
    {
        SaveGame(GameManager.gameSlot);
    }
}
