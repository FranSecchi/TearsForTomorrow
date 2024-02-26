using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Combination", order = 1)]
public class ItemCombination : ItemInfo
{
    public ItemInfo combo1;
    public ItemInfo combo2;
}
