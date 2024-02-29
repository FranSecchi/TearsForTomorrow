using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Dialogue/Nodes", order = 1)]
public class DialogueNode : ScriptableObject
{
    public List<DialogueOption> Options;
    public float RespostaTime;
    public string RespostaKeyText;
    public string NodeKeyText;
}
