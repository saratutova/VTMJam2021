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
    public bool isUsable = true;
    public string ItemName => name;
    public EquipmentType type;
    public Sprite inEquipment;
    public Sprite inEquipmentSelected;
    public Sprite zoomPic;
    public GameAction useAction = default;
}
