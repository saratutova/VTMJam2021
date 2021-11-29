using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Item, Memory
}

[CreateAssetMenu(fileName = "Item", menuName = "SO/New Item", order = 3)]
public class Item : ScriptableObject
{
    public string itemName;
    public EquipmentType type;
    public Sprite inEquipment;
    public Sprite zoomPic;
}
