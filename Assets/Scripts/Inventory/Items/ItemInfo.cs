using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Regular", order = 1)]
public class ItemInfo : ScriptableObject
{
    public Transform prefab;
    public Sprite img;
    public string nameKey;
    public string descriptionKey;
    public ItemInfo combination;
}
