using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : LocalizedText
{
    //Definir botons al GameObject amb aquest Script per escollir opcions
    public GameObject DialoguePanel;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Speech;
    public TextMeshProUGUI[] Options;

    private Animator panelAnimator;
    private DialogueNode currentNode;
    private GameObject talker;

    protected override void Initialize()
    {
        panelAnimator = DialoguePanel.GetComponent<Animator>();
        for (int i = 0; i < Options.Length; i++)
        {

            Options[i].transform.parent.gameObject.SetActive(false);
        }
        HideDialogue();
    }
    private void ShowDialogue()
    {
        //DialoguePanel.SetActive(true);
        panelAnimator.SetBool("Show", true);
    }
    private void HideDialogue()
    {
        panelAnimator.SetBool("Show", false);
        //DialoguePanel.SetActive(false);
    }

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
        endNode.OnChosen(talker);
        HideDialogue();
    }

    internal void StartConversation(Conversation newConversation, GameObject talking)
    {
        talker = talking;
        currentNode = newConversation.StartNode;
        Name.text = newConversation.Name;
        SetText(currentNode);
        ShowDialogue();
    }
    private void SetText(DialogueNode node)
    {
        Speech.text = GetText(node.NodeKeyText);
        for (int i = 0; i < Options.Length; i++)
        {
            if (i < node.Options.Count)
            {
                Options[i].transform.parent.gameObject.SetActive(true);
                Options[i].text = GetText(node.Options[i].OptionKeyText);
            }
            else
            {
                Options[i].transform.parent.gameObject.SetActive(false);
            }
        }
    }

    protected override void OnLanguageChanged()
    {
        SetText(currentNode);
    }
}
