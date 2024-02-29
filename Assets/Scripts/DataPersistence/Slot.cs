using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public static GameSlot selected;
    [SerializeField] private GameObject confirmationPanel;
    public GameSlot slot;
    public bool reset = false;
    public TextMeshProUGUI text;

    private DataPersistenceManager dataManager;
    private Button button;
    private Image img;
    // Start is called before the first frame update
    void OnEnable()
    {
        dataManager = DataPersistenceManager.instance;
        button = GetComponent<Button>();
        img = GetComponent<Image>();
        if (dataManager.isEmpty(slot))
        {
            if (!reset)
            {
                var alpha = img.color;
                alpha.a *= 0.5f;
                img.color = alpha;
                button.enabled = false;
            }
        }
        else text.text = slot.ToString();
    }

    private void NewGame()
    {
        if (!dataManager.isEmpty(slot))
        {
            selected = slot;
            confirmationPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(false);
            GameManager.instance.LoadNewGame(slot);
            //GameManager.LoadScene...
        }
    }
    private void ContinueGame()
    {
        GameManager.instance.LoadGame(slot);
    }

    public void OnClick()
    {
        if (reset)
        {
            NewGame();
        }
        else ContinueGame();
    }
    public void Cancel()
    {
        confirmationPanel.SetActive(false);
    }
    public void Confirm()
    {
        confirmationPanel.SetActive(false);
        GameManager.instance.LoadNewGame(slot);
    }
}
