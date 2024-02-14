using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnWorld : DialogueManager
{
    public Transform PointTo;
    protected override void HideDialogue()
    {
        DialoguePanel.SetActive(false);
    }

    protected override void ShowDialogue()
    {
        DialoguePanel.SetActive(true);
    }

    protected override void Initialize()
    {
        DialoguePanel.transform.LookAt(DialoguePanel.transform.position + PointTo.transform.rotation * Vector3.forward,
                PointTo.transform.rotation * Vector3.up);
        HideDialogue();
    }
}
