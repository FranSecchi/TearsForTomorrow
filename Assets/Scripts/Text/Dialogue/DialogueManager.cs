using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions;

public abstract class DialogueManager : LocalizedText
{
    //Definir botons al GameObject amb aquest Script per escollir opcions
    public GameObject DialoguePanel;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Speech;
    public TextMeshProUGUI Answer;
    public TextMeshProUGUI[] Options;
    private GameObject talking;
    private DialogueNode currentNode;
    private bool conversating = false;

    public bool Conversating { get => conversating; set => conversating = value; }

    private void Start()
    {
        Initialize();
    }
    protected abstract void Initialize();
    protected abstract void ShowDialogue();
    protected abstract void HideDialogue();

    public void OptionChosen(int option)
    {
        currentNode = currentNode.Options[option].NextNode;
        SetText(currentNode);

        if (currentNode is EndNode)
        {
            DoEndNode(currentNode as EndNode);
        }
        else
        {
            SetText(currentNode);
        }

    }

    private void DoEndNode(EndNode endNode)
    {
        endNode.OnChosen(talking);
        FinishConversation();
    }

    internal void FinishConversation()
    {
        PlayerAnimation.instance.Talk(false);
        conversating = false;
        HideDialogue();
    }
    internal void StartConversation(Conversation newConversation, GameObject talker)
    {
        if (conversating)
            return;
        talking = talker;
        currentNode = newConversation.StartNode;
        Name.text = newConversation.Name;
        conversating = true;
        SetText(currentNode);
        ShowDialogue();
    }
    private void SetText(DialogueNode node)
    {
        Speech.text = GetText(node.NodeKeyText, TextType.Dialeg);
        StartCoroutine(PrintAnswer(node));
    }

    private IEnumerator PrintAnswer(DialogueNode node)
    {
        Answer.text = "";
        for (int i = 0; i < Options.Length; i++)
        {
            Options[i].transform.parent.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(node.RespostaTime);
        Speech.text = "";
        Answer.text = GetText(node.RespostaKeyText, TextType.Dialeg);
        for (int i = 0; i < node.Options.Count; i++)
        {
            Options[i].transform.parent.gameObject.SetActive(true);
            Options[i].text = GetText(node.Options[i].OptionKeyText, TextType.Dialeg);
        }
    }

    protected override void OnLanguageChanged()
    {
        if (currentNode != null)
            SetText(currentNode);
    }
}
