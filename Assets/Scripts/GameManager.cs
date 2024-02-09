using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
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
    //Load diferent scene methods
}
