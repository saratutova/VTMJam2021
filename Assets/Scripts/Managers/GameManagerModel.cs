using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Checks
{
    public string name;
    public bool value;
}

public class GameManagerModel : MonoBehaviour
{
    [SerializeField] private Scenery _startScenery;
    [SerializeField] private List<Checks> _checks = new List<Checks>();
    private int _focus = 0;
    private List<Item> _items = new List<Item>();

    public int Focus { get => _focus; set => _focus = value; }
    public Scenery StartScenery => _startScenery;

    public List<Item> AllItems => _items;
    public List<Item> GetMemories => _items.Where(x => x.type == EquipmentType.Memory).ToList();
    public List<Item> GetItems => _items.Where(x => x.type == EquipmentType.Item).ToList();

    public bool Check(string checkName)
    {
        var check = _checks.FirstOrDefault(x => x.name.Equals(checkName));
        if (check == default)
        {
            Debug.Log($"COULDN'T FIND {checkName}");
            return false;
        }
        else
        {
            return check.value;
        }
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }
    
    public void RemoveItem(Item item)
    {
        _items.Remove(item);
    }

    internal void SetCheck(string checkName, bool value)
    {
        var check = _checks.FirstOrDefault(x => x.name.Equals(checkName));
        if (check == default)
        {
            Debug.Log($"COULDN'T FIND {checkName}");
            return;
        }
        check.value = value;
    }
}
