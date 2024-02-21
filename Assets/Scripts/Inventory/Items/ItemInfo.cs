using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class ItemInfo : ScriptableObject
{
    public Sprite img;
    public string nameKey;
    public string descriptionKey;
}
