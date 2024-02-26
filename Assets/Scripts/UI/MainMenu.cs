using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject newGameButton;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject continueGame;
    [SerializeField] private GameObject newGame;
    private DataPersistenceManager dataManager;
    private void Start()
    {
        dataManager = DataPersistenceManager.instance;
        HideMenu(false);
    }

    private void HideMenu(bool hide)
    {
        if (hide)
        {
            HideButton(continueButton, true);
            HideButton(newGameButton, true);
        }
        else
        {
            HideButton(continueButton, false);
            HideButton(newGameButton, false);
        }
    }

    private void HideButton(GameObject b, bool hide)
    {
        var alpha = b.GetComponent<Image>().color;
        alpha.a = hide ? 0.5f : 1f;
        b.GetComponent<Image>().color = alpha;
        b.GetComponent<Button>().enabled = !hide;
    }

    private void Update()
    {
        //if (dataManager.GameData != null)
        //{

        //}
    }
    public void NewGame()
    {
        if (newGame.activeSelf)
        {
            newGame.SetActive(false);
            HideMenu(false);
        }
        else
        {
            newGame.SetActive(true);
            HideMenu(true);
        }
    }
    public void ContinueGame()
    {
        if (continueGame.activeSelf)
        {
            continueGame.SetActive(false);
            HideMenu(false);
        }
        else
        {
            continueGame.SetActive(true);
            HideMenu(true);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        //Application.Quit();
    }
}
