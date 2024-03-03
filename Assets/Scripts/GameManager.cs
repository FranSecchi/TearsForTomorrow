using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameSlot gameSlot;
    public static GameManager instance = null;
    private DataPersistenceManager dataManager;
    public LoadSceneAsync sceneLoader;
    public Transform player;
    private Camera currentCamera;
    private List<Saveable> salvables;
    public Camera CurrentCamera { get => currentCamera; set => currentCamera = value; }
    void Awake()
    {
        if (instance == null)
        {

            instance = this;
            sceneLoader = GetComponent<LoadSceneAsync>();
            GameObject go = new GameObject("GameDataManager");
            dataManager = go.AddComponent<DataPersistenceManager>();
            currentCamera = Camera.main;
            DontDestroyOnLoad(gameObject);
            salvables = new List<Saveable>();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void LoadMenu()
    {
        dataManager.SaveGame(gameSlot);
        salvables = new List<Saveable>();
        SceneManager.LoadScene(Parameter.StartMenu_SCENE);
    }
    public void AddSaveable(Saveable saveable)
    {
        salvables.Add(saveable);
    }
    internal void SaveData(ref GameData gameData)
    {
        //gameData.position = player.position;
        //gameData.rotation = player.forward;
        foreach(Saveable s in salvables)
        {
            s.Save(ref gameData);
        }
    }

    internal void LoadData(GameData gameData)
    {
        //player.position = gameData.position;
        //player.forward = gameData.rotation;
        foreach (Saveable s in salvables)
        {
            s.Load(gameData);
        }
    }
    //Load diferent scene methods
    public void LoadGame(GameSlot slot)
    {
        gameSlot = slot;
        sceneLoader.LoadScene("NewScene");
    }

    internal void LoadNewGame(GameSlot slot)
    {
        gameSlot = slot;
        dataManager.NewGame(gameSlot);
        sceneLoader.LoadScene("NewScene");
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "NewScene")
        {
            dataManager.LoadGame(gameSlot);
        }
    }
}
