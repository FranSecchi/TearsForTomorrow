using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnUI : DialogueManager
{
    private Animator panelAnimator;

    protected override void HideDialogue()
    {
        panelAnimator.SetBool("Show", false);
    }
    protected override void ShowDialogue()
    {
        panelAnimator.SetBool("Show", true);
    }

    protected override void Initialize()
    {
        panelAnimator = DialoguePanel.GetComponent<Animator>();
        for (int i = 0; i < Options.Length; i++)
        {

            Options[i].transform.parent.gameObject.SetActive(false);
        }
    }


}
